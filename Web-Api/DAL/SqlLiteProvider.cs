using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using Web_Api.Models;

namespace Web_Api.DAL
{
    public class SqlLiteProvider : IDataWorker
    {
        string dbPath = ""; 
        string connectionString = "";
        private SQLiteCommand command;

        public SQLiteConnection DbConn { get; private set; }


        public SqlLiteProvider()
        {
            //dbPath = HttpContext.Current.Server.MapPath("~/App_Data/db/siteDB.db");
            dbPath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/db/siteDB.db");
            connectionString = $"Data Source={dbPath};Version=3;";
            DbConn = new SQLiteConnection(connectionString);
            DbConn.Open();
            command = DbConn.CreateCommand();
        }
        public Participant AddParticipant(Participant participant)
        {
            command.CommandText = $"INSERT INTO Participants  (NameParticipant,AgeParticipant,AvatarParticipant,PartyId) VALUES ({participant.NameParticipant},{participant.AgeParticipant},{participant.AvatarParticipant},{participant.PartyId})";
            try
            {
                command.ExecuteNonQuery();
                command.CommandText = "SELECT seq FROM sqlite_sequence WHERE name = 'Participants'";
                var reader = command.ExecuteReader();
                reader.Read();
                int id = int.Parse(reader["seq"].ToString());
                participant.IdParticipant = id;
            }
            catch(Exception ex)
            {
                participant = null;
            }
            DbConn.Close();
            return participant;
        }

        public Party AddParty(Party party)
        {
            command.CommandText = $"INSERT INTO Party  (NameParty,PlaceParty,DateParty) VALUES ({party.NameParty},{party.PlaceParty},{party.DateParty})";
            try
            {
                command.ExecuteNonQuery();
                command.CommandText = "SELECT seq FROM sqlite_sequence WHERE name = 'Party'";
                var reader = command.ExecuteReader();
                reader.Read();
                int id = int.Parse(reader["seq"].ToString());
                party.IdParty = id;
            }
            catch (Exception ex)
            {
                party = null;
            }
            DbConn.Close();
            return party;
        }

        public string DelParticipant(Participant participant)
        {
            command.CommandText = $"DELETE FROM Participants WHERE IdParticipant = {participant.IdParticipant}";
            string res;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            DbConn.Close();
            res = "ok";
            return res;
        }

        public string DelParty(int id)
        {
            command.CommandText = $"DELETE FROM Party WHERE IdParty = {id}";
            string res;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            DbConn.Close();
            res = "ok";
            return res;
        }

        public string EditParticipant(Participant participant)
        {
            command.CommandText = $"UPDATE Participants SET NameParticipant = {participant.NameParticipant},AgeParticipant={participant.AgeParticipant},AvatarParticipant={participant.AvatarParticipant},PartyId = {participant.PartyId} WHERE IdParticipant = {participant.IdParticipant}";
            string res;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            DbConn.Close();
            res = "ok";
            return res;
        }

        public string EditParty(Party party)
        {
            command.CommandText = $"UPDATE Party SET NameParty = {party.NameParty},PlaceParty={party.PlaceParty},DateParty={party.DateParty} WHERE IdParticipant = {party.IdParty}";
            string res;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            DbConn.Close();
            res = "ok";
            return res;
        }

        public Participant GetParticipant(int id)
        {
            command.CommandText = $"SELECT * FROM Participants WHERE IdParticipant = {id}";
            Participant person = new Participant();
            try
            {
                var reader = command.ExecuteReader();
                reader.Read();
                person.IdParticipant = int.Parse(reader[0].ToString());
                person.NameParticipant = reader[1].ToString();
                person.AgeParticipant = int.Parse(reader[2].ToString());
                person.AvatarParticipant = reader[3].ToString();
            }
            catch (Exception ex)
            {
                person = null;
            }
            DbConn.Close();
            return person;
        }

        public List<Participant> GetParticipants()
        {
            command.CommandText = $"SELECT * FROM Participants";
            List<Participant> persons = new List<Participant>();
            try
            {
                var reader = command.ExecuteReader();
                reader.Read();
                persons.Add(new Participant
                {
                    IdParticipant = int.Parse(reader[0].ToString()),
                    NameParticipant = reader[1].ToString(),
                    AgeParticipant = int.Parse(reader[2].ToString()),
                    AvatarParticipant = reader[3].ToString()
                });
            }
            catch (Exception ex)
            {
                persons = null;
            }
            DbConn.Close();
            return persons;
        }

        public List<Party> GetParties()
        {
            command.CommandText = $"SELECT * FROM Party ";
            List<Party> parties = new List<Party>();
            try
            {
                var reader = command.ExecuteReader();
                reader.Read();
                parties.Add(new Party
                {
                    IdParty = int.Parse(reader[0].ToString()),
                    NameParty = reader[1].ToString(),
                    PlaceParty = reader[2].ToString(),
                    DateParty = reader[3].ToString()
                });
            }
            catch (Exception ex)
            {
                parties = null;
            }
            DbConn.Close();
            return parties;
        }

        public Party GetParty(int id)
        {
            command.CommandText = $"SELECT * FROM Party WHERE IdParty = {id}";
            Party party = new Party();
            try
            {
                var reader = command.ExecuteReader();
                reader.Read();
                party.IdParty = int.Parse(reader[0].ToString());
                party.NameParty = reader[1].ToString();
                party.PlaceParty = reader[2].ToString();
                party.DateParty = reader[3].ToString();           
            }
            catch (Exception ex)
            {
                party = null;
            }
            DbConn.Close();
            return party;
        }

        public List<Participant> GetPartyParticipant(Party party)
        {
            command.CommandText = $"SELECT * FROM Participants WHERE PartyId = {party.IdParty}";
            List<Participant> persons = new List<Participant>();
            try
            {
                var reader = command.ExecuteReader();
                reader.Read();
                persons.Add(new Participant
                {
                    IdParticipant = int.Parse(reader[0].ToString()),
                    NameParticipant = reader[1].ToString(),
                    AgeParticipant = int.Parse(reader[2].ToString()),
                    AvatarParticipant = reader[3].ToString()
                });
            }
            catch (Exception ex)
            {
                persons = null;
            }
            DbConn.Close();
            return persons;
        }
    }
}