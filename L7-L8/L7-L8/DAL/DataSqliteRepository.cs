using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using L7_L8.Models;
using System.Data.SQLite;


namespace L7_L8.DAL
{
    public class DataSqliteRepository : IDataRepository
    {
        string dbPath = "";
        string connectionString = "";
        public DataSqliteRepository()
        {
            dbPath = "C:\\Users\\Administrator\\source\\repos\\coursesAsp\\L7-L8\\L7-L8\\SiteData\\db\\siteDB.db";
            connectionString = "Data Source=" + dbPath + ";Version=3;";
        }
        public Participant GetParticipant(int id)
        {
            var DbConn = new SQLiteConnection(connectionString);
            DbConn.Open();
            var command = DbConn.CreateCommand();
            command.CommandText = $"SELECT * FROM Participants WHERE IdParticipant = {id}";
            var reader = command.ExecuteReader();
            Participant men = new Participant();
            while (reader.Read())
            {
                men.IdParticipant = int.Parse(reader["IdParticipant"].ToString());
                men.NameParticipant = reader["NameParticipant"].ToString();
                men.AgeParticipant = int.Parse(reader["AgeParticipant"].ToString());
                men.AvatarParticipant = reader["AvatarParticipant"].ToString();
            }
            DbConn.Close();
            return men;
        }

        public List<Participant> GetParticipants()
        {
            var DbConn = new SQLiteConnection(connectionString);
            DbConn.Open();
            var command = DbConn.CreateCommand();
            command.CommandText = $"SELECT * FROM Participants";
            var reader = command.ExecuteReader();
            var participants = new List<Participant>();
            while (reader.Read())
            {
                var men = new Participant();
                men.IdParticipant = int.Parse(reader["IdParticipant"].ToString());
                men.NameParticipant = reader["NameParticipant"].ToString();
                men.AgeParticipant = int.Parse(reader["AgeParticipant"].ToString());
                men.AvatarParticipant = reader["AvatarParticipant"].ToString();
            }
            DbConn.Close();
            return participants;
        }

        public List<Party> GetParties()
        {
            SQLiteConnection DbConn = new SQLiteConnection(connectionString);
            DbConn.Open();
            var command = DbConn.CreateCommand();
            command.CommandText = $"SELECT * FROM Party";
            var reader = command.ExecuteReader();
            var parties = new List<Party>();
            while (reader.Read())
            {
                var party = new Party();
                party.IdParty = int.Parse(reader["IdParty"].ToString());
                party.NameParty = reader["NameParty"].ToString();
                party.PlaceParty = reader["PlaceParty"].ToString();
                party.DateParty = reader["DateParty"].ToString();
                parties.Add(party);
            }
            DbConn.Close();
            return parties;
        }

        public Party GetParty(int id)
        {
            var DbConn = new SQLiteConnection(connectionString);
            DbConn.Open();
            var command = DbConn.CreateCommand();
            command.CommandText = $"SELECT * FROM Party WHERE IdParty = {id}";
            var reader = command.ExecuteReader();
            Party party = new Party();
            while (reader.Read())
            {
                party.IdParty = int.Parse(reader["IdParty"].ToString());
                party.NameParty = reader["NameParty"].ToString();
                party.PlaceParty = reader["PlaceParty"].ToString();
                party.DateParty = reader["DateParty"].ToString();
            }
            DbConn.Close();
            return party;
        }

        public Party AddParty(Party party)
        {
            var DbConn = new SQLiteConnection(connectionString);
            DbConn.Open();
            var command = DbConn.CreateCommand();
            command.Parameters.Add(new SQLiteParameter("NameParty", party.NameParty));
            command.Parameters.Add(new SQLiteParameter("PlaceParty", party.PlaceParty));
            command.Parameters.Add(new SQLiteParameter("DateParty", party.DateParty));
            command.CommandText = "INSERT INTO Party (NameParty,PlaceParty,DateParty) VALUES (@NameParty,@PlaceParty,@DateParty)";
            command.ExecuteNonQuery();
            command.CommandText = "SELECT seq FROM sqlite_sequence WHERE name = 'Party'";
            var reader = command.ExecuteReader();
            reader.Read();
            int id = int.Parse(reader["seq"].ToString());
            party.IdParty = id;
            return party;
        }

    }
}