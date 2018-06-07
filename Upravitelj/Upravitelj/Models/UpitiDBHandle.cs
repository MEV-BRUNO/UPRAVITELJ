using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Web.Security;
using System.Configuration;
using PagedList;

namespace Upravitelj.Models
{

    public class UpitiDBHandle
    {
        private MySqlConnection con;
        string str = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<UpitiModels> GetUpite()
        {
            connection();
            List<UpitiModels> upiti = new List<UpitiModels>();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id,datum,naslov,opis,odgovoren  FROM UpitiMdodels ORDER BY naslov ASC";
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            UpitiModels emp = new UpitiModels()
                            {
                                id = Convert.ToInt32(sdr["id"]),
                                datum = Convert.ToInt32(sdr["datum"]),
                                naslov = sdr["naslov"].ToString(),
                                opis = sdr["opis"].ToString()
                            };
                            if (emp.naslov.Length > 0)
                                upiti.Add(emp);
                        }
                    }
                }
                con.Close();
            }
            return upiti;
        }

        public List<UpitiModels> GetUpite_2(string searchData)
        {
            connection();
            List<UpitiModels> upiti = new List<UpitiModels>();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id,datum,naslov,opis,odgovoren  FROM UpisiModels WHERE " +
                    " Naslov like '%" + searchData + "%' " +
                    " ORDER BY id ASC";
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            UpitiModels emp = new UpitiModels()
                            {
                                id = Convert.ToInt32(sdr["id"]),
                                datum = Convert.ToInt32(sdr["datum"]),
                                naslov = sdr["naslov"].ToString(),
                                opis = sdr["opis"].ToString()
                            };
                            if (emp.naslov.Length > 0)
                                upiti.Add(emp);
                        }
                    }
                }
                con.Close();
            }
            return upiti;
        }

        public string dodajUpit(UpitiModels data)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO UpitiModels(id,datum,naslov,opis,odgovoren) " +
                        " VALUES(@id,@naslov,@opis)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", data.id);
                    cmd.Parameters.AddWithValue("@datum", data.id);
                    cmd.Parameters.AddWithValue("@naslov", data.naslov);
                    cmd.Parameters.AddWithValue("@opis", data.opis);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return "OK";
                }
            }
            catch (Exception err)
            {
                con.Close();
                return "Error";
            }
        }
        public UpitiModels getUpitID(int _id)
        {
            connection();
            UpitiModels upiti = new UpitiModels();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id,datum,naslov,opis,odgovoren  FROM UpitiModels WHERE id=+@id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", _id);
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            upiti = new UpitiModels()
                            {
                                id = Convert.ToInt32(sdr["id"]),
                                id = Convert.ToInt32(sdr["datum"]),
                                naslov = sdr["naslov"].ToString(),
                                opis = sdr["opis"].ToString()
                            };
                        }
                    }
                }
                con.Close();
            }
            return upiti;
        }

        public string updateUpit(UpitiModels data)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE UpitiModels SET naslov = @naslov, datum = @datum, opis = @opis  WHERE id = @id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", data.id);
                    cmd.Parameters.AddWithValue("@datum", data.datum);
                    cmd.Parameters.AddWithValue("@naslov", data.naslov);
                    cmd.Parameters.AddWithValue("@opis", data.opis);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return "OK";
                }
            }
            catch (Exception err)
            {
                con.Close();
                return "Error";
            }
        }

        public string deleteUpti(int _id)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = "DELETE FROM UpitiModels WHERE id = @id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", _id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return "OK";
                }
            }
            catch (Exception err)
            {
                con.Close();
                return "Error";
            }
        }

    }
}