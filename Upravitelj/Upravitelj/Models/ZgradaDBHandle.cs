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

    public class ZgradaDBHandle
    {
        private MySqlConnection con;
        string str = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
            con = new MySqlConnection(constring);
        }

        public List<Zgrada> GetZgrade()
        {
            connection();
            List<Zgrada> zgrade = new List<Grad>();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_zgrada, naziv, ulica, grad, broj_stanara  FROM grad ORDER BY naziv ASC";
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Zgrada emp = new Zgrada()
                            {
                                id_zgrada = Convert.ToInt32(sdr["id_zgrada"]),
                                naziv = sdr["naziv"].ToString(),
                                ulica = sdr["ulica"].ToString(),
                                grad = sdr["grad"].ToString(),
                                broj_stanara = Convert.ToInt32(sdr["broj_stanara"])
                            };
                            if (emp.naziv.Length > 0 && emp.ulica.Length > 0 && emp.grad.Length > 0 && emp.broj_stanara.Length > 0)
                                gradovi.Add(emp);
                        }
                    }
                }
                con.Close();
            }
            return gradovi;
        }

        public List<Zgrada> GetZgrada_2(string searchData)
        {
            connection();
            List<Zgrada> zgrade = new List<Zgrada>();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_zgrada, naziv, ulica, grad, broj_stanara  FROM grad WHERE " +
                    " naziv like '%"+ searchData+"%' " +
                    " ORDER BY id ASC";
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Zgrada emp = new Zgrada()
                            {
                                id_zgrada = Convert.ToInt32(sdr["id_zgrada"]),
                                naziv = sdr["naziv"].ToString(),
                                ulica = sdr["ulica"].ToString(),
                                grad = sdr["grad"].ToString(),
                                broj_stanara = Convert.ToInt32(sdr["broj_stanara"])
                            };
                            if (emp.naziv.Length > 0 && emp.ulica.Length > 0 && emp.grad.Length > 0 && emp.broj_stanara.Length > 0)
                                gradovi.Add(emp);
                        }
                    }
                }
                con.Close();
            }
            return gradovi;
        }

        public string addZgrada(Zgrada data)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO zgrada(id_zgrada,naziv,ulica,grad,broj_stanara) " +
                        " VALUES(@id_zgrada,@naziv,@ulica,@grad,@broj_stanara)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_zgrada", data.id_zgrada);
                    cmd.Parameters.AddWithValue("@naziv", data.naziv);
                    cmd.Parameters.AddWithValue("@ulica", data.ulica);
                    cmd.Parameters.AddWithValue("@grad", data.grad);
                    cmd.Parameters.AddWithValue("@broj_stanara", data.broj_stanara);

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
        public Zgrada getZgradaID(int _id)
        {
            connection();
            Zgrada zgrada = new Zgrada();
            con.ConnectionString = str;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT id_zgrada, naziv, ulica, grad, broj_stanara  FROM grad WHERE id=+@id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", _id);
                con.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            zgrada = new Zgrada()
                            {
                                id_zgrada = Convert.ToInt32(sdr["id_zgrada"]),
                                naziv = sdr["naziv"].ToString(),
                                ulica = sdr["ulica"].ToString(),
                                grad = sdr["grad"].ToString(),
                                broj_stanara = Convert.ToInt32(sdr["broj_stanara"])
                            };
                        }
                    }
                }
                con.Close();
            }
            return grad;
        }

        public string updateZgrada(Zgrada data)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE zgrada SET naziv = @naziv, ulica = @ulica, grad = @grad, broj_stanara = @broj_stanara  WHERE id = @id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", data.id);
                    cmd.Parameters.AddWithValue("@naziv", data.naziv);
                    cmd.Parameters.AddWithValue("@ulica", data.ulica);
                    cmd.Parameters.AddWithValue("@grad", data.grad);
                    cmd.Parameters.AddWithValue("@broj_stanara", data.broj_stanara);
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

        public string deleteZgrada(int _id)
        {
            try
            {
                connection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.CommandText = "DELETE FROM zgrada WHERE id = @id";
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