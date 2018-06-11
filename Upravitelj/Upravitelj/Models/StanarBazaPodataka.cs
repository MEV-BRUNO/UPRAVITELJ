using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Web.Security;
using System.Configuration;

namespace Upravitelj.Models
{

    public class StanarBazaPodataka
    {
        private MySqlConnection con;
        string str = ConfigurationManager.ConnectionStrings["upravitelj_db_24_04_2018"].ConnectionString;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["upravitelj_db_24_04_2018"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<Stanar> GetStanar()
        {
            connection();
            List<Stanar> stanari = new List<Stanar>();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_stanar,ime_prezime,id_zgrada,vrsta_korisnika,mob,email,lozinka,aktivacijski_link,aktivan FROM stanar ORDER BY id_stanar ASC";
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Stanar emp = new Stanar()
                            {
                                id_stanar = Convert.ToInt32(sdr["id_stanar"]),
                                Ime_prezime = sdr["ime_prezime"].ToString(),
                                id_zgrada = Convert.ToInt32(sdr["id_zgrada"]),
                                vrsta_korisnika = sdr["vrsta_korisnika"].ToString(),
                                mob = sdr["zupanija"].ToString(),
                                email = sdr["email"].ToString(),
                                lozinka = sdr["lozinka"].ToString(),
                                aktivacijski_link = sdr["aktivacijski_link"].ToString(),
                                aktivan = Convert.ToInt32(sdr["aktivan"])
                            };
                            if (emp.Ime_prezime.Length > 0)
                                stanari.Add(emp);
                        }
                    }
                }
                con.Close();
            }
            return stanari;
        }

        public List<Stanar> GetStanar_2(string searchData)
        {
            connection();
            List<Stanar> stanar = new List<Stanar>();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_stanar,ime_prezime,id_zgrada,vrsta_korisnika,mob,email,lozinka,aktivacijski_link,aktivan FROM stanar WHERE " +
                    " naziv like '%" + searchData + "%' " +
                    " ORDER BY id_stanar ASC";
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Stanar emp = new Stanar()
                            {
                                id_stanar = Convert.ToInt32(sdr["id_stanar"]),
                                Ime_prezime = sdr["ime_prezime"].ToString(),
                                id_zgrada = Convert.ToInt32(sdr["id_zgrada"]),
                                vrsta_korisnika = sdr["vrsta_korisnika"].ToString(),
                                mob = sdr["zupanija"].ToString(),
                                email = sdr["email"].ToString(),
                                lozinka = sdr["lozinka"].ToString(),
                                aktivacijski_link = sdr["aktivacijski_link"].ToString(),
                                aktivan = Convert.ToInt32(sdr["aktivan"])
                            };
                            if (emp.Ime_prezime.Length > 0)
                                stanar.Add(emp);
                        }
                    }
                }
                con.Close();
            }
            return stanar;
        }

        public string addStanar(Stanar data)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO stanar(id_stanar,ime_prezime,id_zgrada,vrsta_korisnika,mob,email,lozinka,aktivacijski_link,aktivan) " +
                        " VALUES(@id_stanar,@ime_prezime,@id_zgrada,@vrsta_korisnika,@mob,@email,@lozinka,@aktivacijski_link,@aktivan)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", data.id_stanar);
                    cmd.Parameters.AddWithValue("@naziv", data.Ime_prezime);
                    cmd.Parameters.AddWithValue("@zupanija", data.id_zgrada);
                    cmd.Parameters.AddWithValue("@id", data.vrsta_korisnika);
                    cmd.Parameters.AddWithValue("@naziv", data.mob);
                    cmd.Parameters.AddWithValue("@zupanija", data.email);
                    cmd.Parameters.AddWithValue("@id", data.lozinka);
                    cmd.Parameters.AddWithValue("@naziv", data.aktivacijski_link);
                    cmd.Parameters.AddWithValue("@zupanija", data.aktivan);
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
        public Stanar getStanarID(int _id)
        {
            connection();
            Stanar stanar = new Stanar();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_stanar,ime_prezime,id_zgrada,vrsta_korisnika,mob,email,lozinka,aktivacijski_link,aktivan  FROM grad WHERE id=+@id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", _id);
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            stanar = new Stanar()
                            {
                                id_stanar = Convert.ToInt32(sdr["id_stanar"]),
                                Ime_prezime = sdr["ime_prezime"].ToString(),
                                id_zgrada = Convert.ToInt32(sdr["id_zgrada"]),
                                vrsta_korisnika = sdr["vrsta_korisnika"].ToString(),
                                mob = sdr["zupanija"].ToString(),
                                email = sdr["email"].ToString(),
                                lozinka = sdr["lozinka"].ToString(),
                                aktivacijski_link = sdr["aktivacijski_link"].ToString(),
                                aktivan = Convert.ToInt32(sdr["aktivan"])
                            };
                        }
                    }
                }
                con.Close();
            }
            return stanar;
        }

        public string updateStanar(Stanar data)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE stanar SET id_stanar = @id_stanar, ime_prezime = @ime_prezime,id_zgrada = @id_zgrada,vrsta_korisnika = @vrsta_korisnika,mob = @mob,email = @email,lozinka = @lozinka,aktivacijski_link = @aktivacijski_link,aktivan = @aktivan  WHERE id = @id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", data.id_stanar);
                    cmd.Parameters.AddWithValue("@naziv", data.Ime_prezime);
                    cmd.Parameters.AddWithValue("@zupanija", data.id_zgrada);
                    cmd.Parameters.AddWithValue("@id", data.vrsta_korisnika);
                    cmd.Parameters.AddWithValue("@naziv", data.mob);
                    cmd.Parameters.AddWithValue("@zupanija", data.email);
                    cmd.Parameters.AddWithValue("@id", data.lozinka);
                    cmd.Parameters.AddWithValue("@naziv", data.aktivacijski_link);
                    cmd.Parameters.AddWithValue("@zupanija", data.aktivan);
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

        public string deleteStanar(int _id)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = "DELETE FROM stanar WHERE id = @id";
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