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

    public class UpitBazaPodataka
    {
        private MySqlConnection con;
        string str = ConfigurationManager.ConnectionStrings["upravitelj_db_24_04_2018"].ConnectionString;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["upravitelj_db_24_04_2018"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<Upit> GetUpit()
        {
            connection();
            List<Upit> upiti = new List<Upit>();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_upit,id_stanar,datum,naslov,opis,dogovoreno FROM upit ORDER BY id_upit ASC";
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Stanar emp = new Stanar()
                            {
                                id_upit = Convert.ToInt32(sdr["id_upit"]),
                                id_stanar = Convert.ToInt32(sdr["id_stanar"]),
                                datum = sdr["datum"].datetime(),
                                naslov = sdr["naslov"].ToString(),
                                opis = sdr["opis"].ToString(),
                                dogovoreno = sdr["dogovoreno"].ToString()
                            };
                            if (emp.naslov.Length > 0)
                                stanari.Add(emp);
                        }
                    }
                }
                con.Close();
            }
            return upiti;
        }

        public List<upit> GetUpit_2(string searchData)
        {
            connection();
            List<Upit> upit = new List<Upit>();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_upit,id_stanar,datum,naslov,opis,dogovoreno FROM upit WHERE " +
                    " naslov like '%" + searchData + "%' " +
                    " ORDER BY id_upit ASC";
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Upit emp = new Upit()
                            {
                                id_upit = Convert.ToInt32(sdr["id_upit"]),
                                id_stanar = Convert.ToInt32(sdr["id_stanar"]),
                                datum = sdr["datum"].datetime(),
                                naslov = sdr["naslov"].ToString(),
                                opis = sdr["opis"].ToString(),
                                dogovoreno = sdr["dogovoreno"].ToString()
                            };
                            if (emp.naslov.Length > 0)
                                upit.Add(emp);
                        }
                    }
                }
                con.Close();
            }
            return upit;
        }

        public string addUpit(Upit data)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO upit(id_upit,id_stanar,datum,naslov,opis,dogovoreno) " + " VALUES(@id_upit,@id_stanar,@datum,@naslov,@opis,@dogovoreno)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_upit", data.id_upit);
                    cmd.Parameters.AddWithValue("@id_stanar", data.id_stanar);
                    cmd.Parameters.AddWithValue("@datum", data.datum);
                    cmd.Parameters.AddWithValue("@naslov", data.naslov);
                    cmd.Parameters.AddWithValue("@opis", data.opis);
                    cmd.Parameters.AddWithValue("@dogovoreno", data.dogovoreno);
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
        public Upit getUpitID(int _id)
        {
            connection();
            Upit upit = new UPit();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_upit,id_stanar,datum,naslov,opis,dogovoreno FROM upit WHERE id=+@id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", _id);
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            upit = new Upit()
                            {
                                id_upit = Convert.ToInt32(sdr["id_upit"]),
                                id_stanar = Convert.ToInt32(sdr["id_stanar"]),
                                datum = sdr["datum"].datetime(),
                                naslov = sdr["naslov"].ToString(),
                                opis = sdr["opis"].ToString(),
                                dogovoreno = sdr["dogovoreno"].ToString()
                            };
                        }
                    }
                }
                con.Close();
            }
            return upit;
        }

        public string updateUpit(Upit data)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE upit SET id_upit = @id_upit, id_stanar = @id_stanar,datum = @datum,naslov = @naslov,opis = @opis,dogovreno = @dogovoreno WHERE id = @id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_upit", data.id_upit);
                    cmd.Parameters.AddWithValue("@id_stanar", data.id_stanar);
                    cmd.Parameters.AddWithValue("@datum", data.datum);
                    cmd.Parameters.AddWithValue("@naslov", data.naslov);
                    cmd.Parameters.AddWithValue("@opis", data.opis);
                    cmd.Parameters.AddWithValue("@dogovoreno", data.dogovoreno);
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

        public string deleteUpit(int _id)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = "DELETE FROM upit WHERE id = @id";
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