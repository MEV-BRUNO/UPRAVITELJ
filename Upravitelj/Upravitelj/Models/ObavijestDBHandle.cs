using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace Upravitelj.Models
{
    public class ObavijestDBHandle
    {

        private MySqlConnection con;
        string str = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<Obavijest> GetObavijest()
        {
            connection();
            List<Obavijest> obavijest = new List<Obavijest>();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_obavijest, datum, naslov, opis, dokument, slika, kategorija, vidljiv  FROM obavijest ORDER BY datum ASC";
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Obavijest emp = new Obavijest()
                            {
                                id_obavijest = Convert.ToInt32(sdr["id_obavijest"]),
                                datum = Convert.ToDateTime(sdr["datum"]),
                                naslov = sdr["naslov"].ToString(),
                                opis = sdr["opis"].ToString(),
                                dokument = Convert.ToChar(sdr["dokument"]),
                                slika = sdr["slika"].ToString(),
                                kategorija = Convert.ToInt32(sdr["kategorija"]),
                                vidljiv = Convert.ToBoolean(Boolean)(sdr["vidljiv"])
                            };
                            if (emp.naslov.Length > 0 && emp.opis.Length > 0 )
                                obavijest.Add(emp);
                        }
                    }
                }
                con.Close();
            }
            return obavijest;
        }

        public List<Obavijest> GetObavijest_2(string searchData)
        {
            connection();
            List<Obavijest> obavijest = new List<Obavijest>();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_obavijest, datum, naslov, opis, dokument, slika, kategorija, vidljiv  FROM obavijest WHERE " +
                    " naslov like '%" + searchData + "%' " +
                    " ORDER BY datum ASC";
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Obavijest emp = new Obavijest()
                            {
                                id_obavijest = Convert.ToInt32(sdr["id_obavijest"]),
                                datum = Convert.ToDateTime(sdr["datum"]),
                                naslov = sdr["naslov"].ToString(),
                                opis = sdr["opis"].ToString(),
                                dokument = Convert.ToChar(sdr["dokument"]),
                                slika = sdr["slika"].ToString(),
                                kategorija = Convert.ToInt32(sdr["kategorija"]),
                                vidljiv = Convert.ToBoolean(Boolean)(sdr["vidljiv"])
                            };
                            if (emp.naslov.Length > 0 && emp.opis.Length > 0)
                                obavijest.Add(emp);
                        }
                    }
                }
                con.Close();
            }
            return obavijest;
        }

        public string addObavijest(Obavijest data)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO obavijest(id_obavijest,datum,naslov,opis,dokument,slika,kategorija,vidljiv) " +
                        " VALUES(@id_obavijest,@datum,@naslov,@opis,@dokument,@slika,@kategorija,@vidljiv)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id-obavijest", data.id_obavijest);
                    cmd.Parameters.AddWithValue("@naslov", data.naslov);
                    cmd.Parameters.AddWithValue("@opis", data.opis);
                    cmd.Parameters.AddWithValue("@dokument", data.dokument);
                    cmd.Parameters.AddWithValue("@slika", data.slika);
                    cmd.Parameters.AddWithValue("@kategorija", data.kategorija);
                    cmd.Parameters.AddWithValue("@vidljiv", data.vidljiv);

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
        public Obavijest getObavijestID(int _id)
        {
            connection();
            Obavijest obavijest = new Obavijest();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_obavijest, datum, naslov, opis, dokument, slika, kategorija, vidljiv  FROM obavijest WHERE id_obavijest=+@id_obavijest";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_obavijest", _id);
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            obavijest = new Obavijest()
                            {
                                id_obavijest = Convert.ToInt32(sdr["id_obavijest"]),
                                datum = Convert.ToDateTime(sdr["datum"]),
                                naslov = sdr["naslov"].ToString(),
                                opis = sdr["opis"].ToString(),
                                dokument = Convert.ToChar(sdr["dokument"]),
                                slika = sdr["slika"].ToString(),
                                kategorija = Convert.ToInt32(sdr["kategorija"]),
                                vidljiv = Convert.ToBoolean(Boolean)(sdr["vidljiv"])
                            };
                        }
                    }
                }
                con.Close();
            }
            return obavijest;
        }

        public string updateObavijest(Obavijest data)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE obavijest SET datum = @datum, naslov = @naslov, opis = @opis, dokument = @dokument, slika = @slika, kategorija = @kategorija. vidljiv = @vidljiv  WHERE id_obavijest = @id_obavijest";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_obavijest", data.id_obavijest);
                    cmd.Parameters.AddWithValue("@datum", data.datum);
                    cmd.Parameters.AddWithValue("@naslov", data.naslov);
                    cmd.Parameters.AddWithValue("@opis", data.opis);
                    cmd.Parameters.AddWithValue("@dokument", data.dokument);
                    cmd.Parameters.AddWithValue("@slika", data.slika);
                    cmd.Parameters.AddWithValue("@kategorija", data.kategorija);
                    cmd.Parameters.AddWithValue("@vidljiv", data.vidljiv);
                   
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

        public string deleteObavijest(int _id)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = "DELETE FROM obavijest WHERE id_obavijest = @id_obavijest";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_oobavijest", _id);
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