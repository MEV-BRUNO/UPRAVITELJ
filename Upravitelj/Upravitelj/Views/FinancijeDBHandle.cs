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

    public class FinancijeDBHandle
    {
        private MySqlConnection con;
        string str = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<Financije> GetFinancije()
        {
            connection();
            List<Financije> financije = new List<Financije>();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_financija, id_zgrada, datum, stanje, FROM financije";
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Financije emp = new Financije()
                            {
                                id_financija = Convert.ToInt32(sdr["id_financija"]),
                                id_zgrada = Convert.ToInt32(sdr["id_zgrada"]),
                                datum = sdr["datum"].datetime(),
                                broj_stanara = Convert.ToInt64(sdr["stanje"])
                            };
                            if (emp.id_financija.Length > 0)
                                financije.Add(emp);
                        }
                    }
                }
                con.Close();
            }
            return financije;
        }

        public List<Financije> GetFinancije_2(string searchData)
        {
            connection();
            List<Financije> financije = new List<Financije>();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_financija, id_zgrada, datum, stanje FROM financije ORDER BY id ASC";
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Financije emp = new Financije()
                            {
                                id_financija = Convert.ToInt32(sdr["id_financija"]),
                                id_zgrada = Convert.ToInt32(sdr["id_zgrada"]),
                                datum = sdr["datum"].datetime(),
                                stanje = Convert.ToInt64(sdr["stanje"])
                            };
                            if (emp.id_financija.Length > 0)
                                financije.Add(emp);
                        }
                    }
                }
                con.Close();
            }
            return financije;
        }

        public string addFinancije(Financije data)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO financije(id_financije,id_zgrada,datum,stanje) " +
                        " VALUES(@id_financija,@id_zgrada,@datum,@stanje)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_financija", data.id_financija);
                    cmd.Parameters.AddWithValue("@id_zgrada", data.id_zgrada);
                    cmd.Parameters.AddWithValue("@datum", data.datum);
                    cmd.Parameters.AddWithValue("@stanje", data.stanje);


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
        public Financije getFinancijeID(int _id)
        {
            connection();
            Financije financije = new Financije();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_financija, id_zgrada, datum, stanje  FROM financije WHERE id=+@id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", _id);
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            financije = new Financije()
                            {
                                id_financija = Convert.ToInt32(sdr["id_financija"]),
                                id_zgrada = Convert.ToInt32(sdr["id_zgrada"]),
                                datum = sdr["datum"].datetime(),
                                stanje = Convert.ToInt64(sdr["stanje"])
                            };
                        }
                    }
                }
                con.Close();
            }
            return financije;
        }

        public string updateFinancije(Financije data)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE financije SET datum = @datum, stanje = @stanje WHERE id = @id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", data.id);
                    cmd.Parameters.AddWithValue("@datum", data.datum);
                    cmd.Parameters.AddWithValue("@stanje", data.stanje);
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

        public string deleteFinancije(int _id)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = "DELETE FROM financije WHERE id = @id";
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