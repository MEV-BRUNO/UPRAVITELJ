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

    public class ArhivaDBHandle
    {
        private MySqlConnection con;
        string str = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<Arhiva> GetArhiva()
        {
            connection();
            List<Arhiva> arhiva = new List<Arhiva>();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_arhiva, naziv, datoteka  FROM Arhiva ORDER BY naziv ASC";
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Arhiva emp = new Arhiva()
                            {
                                id_arhiva = Convert.ToInt32(sdr["id_arhiva"]),
                                naziv = sdr["naziv"].ToString(),
                                datoteka = sdr["datoteka"].ToString(),
                            };
                            if (emp.naziv.Length > 0 && emp.datoteka.Length > 0)
                                arhiva.Add(emp);
                        }
                    }
                }
                con.Close();
            }
            return arhiva;
        }

        public List<Arhiva> GetArhiva_2(string searchData)
        {
            connection();
            List<Arhiva> arhiva = new List<Arhiva>();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_zgrada, naziv, datoteka  FROM Arhiva WHERE " +
                    " naziv like '%"+ searchData+"%' " +
                    " ORDER BY id ASC";
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Arhiva emp = new Arhiva()
                            {
                                id_arhiva = Convert.ToInt32(sdr["id_arhiva"]),
                                naziv = sdr["naziv"].ToString(),
                                datoteka = sdr["datoteka"].ToString(),
                            };
                            if (emp.naziv.Length > 0 && emp.ulica.Length > 0)
                                arhiva.Add(emp);
                        }
                    }
                }
                con.Close();
            }
            return arhiva;
        }

        public string addArhiva(Arhiva data)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO Arhiva(id_arhiva,naziv,datoteka) " +
                        " VALUES(@id_arhiva,@naziv,@datoteka)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_arhiva", data.id_zgrada);
                    cmd.Parameters.AddWithValue("@naziv", data.naziv);
                    cmd.Parameters.AddWithValue("@datoteka", data.datoteka);

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
        public Arhiva getArhivaID(int _id)
        {
            connection();
            Arhiva arhiva = new Arhiva();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_arhiva, naziv, datoteka  FROM Arhiva WHERE id=+@id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", _id);
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            arhiva = new Arhiva()
                            {
                                id_arhiva = Convert.ToInt32(sdr["id_arhiva"]),
                                naziv = sdr["naziv"].ToString(),
                                datoteka = sdr["datoteka"].ToString(),
                            };
                        }
                    }
                }
                con.Close();
            }
            return arhiva;
        }

        public string updateArhiva(Arhiva data)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE Arhiva SET naziv = @naziv, datoteka = @datoteka  WHERE id = @id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_arhiva", data.id_arhiva);
                    cmd.Parameters.AddWithValue("@naziv", data.naziv);
                    cmd.Parameters.AddWithValue("@datoteka", data.datoteka);

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

        public string deleteArhiva(int _id)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = "DELETE FROM Arhiva WHERE id = @id";
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