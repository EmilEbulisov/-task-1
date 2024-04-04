using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Knijniymagazin.Controller
{
    internal class Query
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable;

        public Query(string Conn)
        {
            connection = new OleDbConnection(Conn);
            bufferTable = new DataTable();

        }
        //Обновление
        public DataTable UpdateKnigi()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Knigi", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;

        }
        public DataTable UpdatePostuplenie()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM PostuplenieKnig", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;

        }
        public DataTable UpdateAvtor()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM PAROLI", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;

        }
        public DataTable UpdateProdaji()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM ProdanyeKnigi", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;

        }
        //Добавляешь
        public void AddKnigi(int NomerKnigi, string NazvanieKnigi, string JanrKnigi, string AvtorKnigi, int NomerDocumenta, string NomerIzdatelstva, string KolichestvoStranic, string Cena, string KolichestvoEkzenplyarov, string GodIzdaniya)
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO Knigi(NomerKnigi, NazvanieKnigi, JanrKnigi, AvtorKnigi, NomerDocumenta, NomerIzdatelstva, KolichestvoStranic, Cena, KolichestvoEkzenplyarov, GodIzdaniya) VALUES(NomerKnigi, @NazvanieKnigi, @JanrKnigi, @AvtorKnigi, NomerDocumenta, @NomerIzdatelstva, @KolichestvoStranic, @Cena, @KolichestvoEkzenplyarov, @GodIzdaniya)", connection);
            command.Parameters.AddWithValue("NomerKnigi", NomerKnigi);
            command.Parameters.AddWithValue("NazvanieKnigi", NazvanieKnigi);
            command.Parameters.AddWithValue("JanrKnigi", JanrKnigi);
            command.Parameters.AddWithValue("AvtorKnigi", AvtorKnigi);
            command.Parameters.AddWithValue("NomerDocumenta", NomerDocumenta);
            command.Parameters.AddWithValue("NomerIzdatelstva", NomerIzdatelstva);
            command.Parameters.AddWithValue("KolichestvoStranic", KolichestvoStranic);
            command.Parameters.AddWithValue("Cena", Cena);
            command.Parameters.AddWithValue("KolichestvoEkzenplyarov", KolichestvoEkzenplyarov);
            command.Parameters.AddWithValue("GodIzdaniya", GodIzdaniya);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddPostuplenie(int NomerDocumenta, string DataPostypleniyaKnigi, string NaimenovaniePostavshika, string TelefonPostavshika)
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO PostuplenieKnig (NomerDocumenta, DataPostypleniyaKnigi, NaimenovaniePostavshika, TelefonPostavshika) VALUES(NomerDocumenta, @DataPostypleniyaKnigi, @NaimenovaniePostavshika, @TelefonPostavshika)", connection);
            command.Parameters.AddWithValue("NomerDocumenta", NomerDocumenta);
            command.Parameters.AddWithValue("DataPostypleniyaKnigi", DataPostypleniyaKnigi);
            command.Parameters.AddWithValue("NaimenovaniePostavshika", NaimenovaniePostavshika);
            command.Parameters.AddWithValue("TelefonPostavshika", TelefonPostavshika);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void AddProdaji(int NomerZakaza, string KolichestvoZakazov, int NomerKnigi, string DataZakaza, string Summa)
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO ProdanyeKnigi (NomerZakaza, KolichestvoZakazov, NomerKnigi, DataZakaza, Summa) VALUES(NomerZakaza, @KolichestvoZakazov, NomerKnigi, @DataZakaza, @Summa)", connection);
            command.Parameters.AddWithValue("NomerZakaza", NomerZakaza);
            command.Parameters.AddWithValue("KolichestvoZakazov", KolichestvoZakazov);
            command.Parameters.AddWithValue("NomerKnigi", NomerKnigi);
            command.Parameters.AddWithValue("DataZakaza", DataZakaza);
            command.Parameters.AddWithValue("Summa", Summa);
            command.ExecuteNonQuery();
            connection.Close();
        } 
        //Удаление
        public void DeleteKnigi(int NomerKnigi)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM Knigi WHERE NomerKnigi = {NomerKnigi}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DeletePostuplenie(int NomerDocumenta)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM PostuplenieKnig WHERE NomerDocumenta = {NomerDocumenta}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteProdaji(int NomerZakaza)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM ProdanyeKnigi WHERE NomerZakaza = {NomerZakaza}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
    

