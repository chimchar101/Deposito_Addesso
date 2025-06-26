using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connStr = "server=[SERVER];port=[PORT];user=[USER];password=[PASSWORD];database=[DATABASE];";
        MySqlConnection conn = new MySqlConnection(connStr);
        bool esci = false;

        try
        {
            conn.Open();
            Console.WriteLine("Connessione al database riuscita.");

            while (!esci)
            {
                Console.WriteLine("Benvenuto nell'Agenzia di Viaggi.");
                Console.WriteLine("Scegli un'opzione:\n[1] Registrati\n[2] Accedi\n[0] Esci");
                string scelta = Console.ReadLine() ?? "Campo Obbligatorio";
                switch (scelta)
                {
                    case "1":
                        Registrazione(conn);
                        break;
                    case "2":
                        Accesso(conn);
                        break;
                    case "0":
                        Console.WriteLine("Arrivederci!");
                        esci = true;
                        break;
                    default:
                        Console.WriteLine("Opzione non valida.");
                        break;
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Errore di connessione: " + ex.Message);
        }
        finally
        {
            conn.Close();
        }
    }

    private static void Registrazione(MySqlConnection conn)
    {
        Console.WriteLine("REGISTRAZIONE");
        Console.WriteLine("Inserisci il tuo username: ");
        string username = Console.ReadLine() ?? "Campo Obbligatorio";
        Console.WriteLine("Inserisci la tua email: ");
        string email = Console.ReadLine() ?? "Campo Obbligatorio";
        Console.WriteLine("Inserisci la tua password: ");
        string password = Console.ReadLine() ?? "Campo Obbligatorio";
        Console.WriteLine("Inserisci il tuo numero di telefono: ");
        string telefono = Console.ReadLine() ?? "Campo Obbligatorio";

        string query = "INSERT INTO utente (username, email, password, telefono) VALUES (@username, @email, @password, @telefono)";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@email", email);
        cmd.Parameters.AddWithValue("@password", password);
        cmd.Parameters.AddWithValue("@telefono", telefono);

        try
        {
            cmd.ExecuteNonQuery();
            Console.WriteLine("Registrazione completata con successo.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore durante la registrazione: " + ex.Message);
        }
    }

    private static void Accesso(MySqlConnection conn)
    {
        Console.WriteLine("ACCESSO");
        Console.WriteLine("Inserisci il tuo username: ");
        string username = Console.ReadLine() ?? "Campo Obbligatorio";
        Console.WriteLine("Inserisci la tua password: ");
        string password = Console.ReadLine() ?? "Campo Obbligatorio";

        string query = "SELECT * FROM utente WHERE username = @username AND password = @password";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);

        try
        {
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine($"Accesso riuscito per l'utente {username}.");
                if (reader["ruolo"].ToString() == "u")
                {
                    reader.Close();
                    MenuUtente(conn, username);
                }

                else if (reader["ruolo"].ToString() == "a")
                {
                    reader.Close();
                    MenuAdmin(conn, username);
                }
            }

            else
            {
                Console.WriteLine("Username o password errati.");
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine("Errore durante l'accesso: " + ex.Message);
            return;
        }
    }

    private static void MenuUtente(MySqlConnection conn, string username)
    {
        bool logout = false;

        Console.WriteLine($"Benvenuto, {username}!");
        while (!logout)
        {
            Console.WriteLine("Cosa vuoi fare?");
            Console.WriteLine("[1] Visualizza voli disponibili\n[2] Prenota viaggio\n[3] Visualizza prenotazioni\n[0] Logout");
            string scelta = Console.ReadLine() ?? "Campo Obbligatorio";

            switch (scelta)
            {
                case "1":
                    VisualizzaVoli(conn);
                    break;
                case "2":
                    PrenotaViaggio(conn, username); // DA FINIRE
                    break;
                case "3":
                    VisualizzaPrenotazioni(conn, username);
                    break;
                case "0":
                    Console.WriteLine("Logout effettuato.");
                    logout = true;
                    break;
                default:
                    Console.WriteLine("Opzione non valida.");
                    break;
            }
        }
    }

    private static void MenuAdmin(MySqlConnection conn, string username)
    {
        bool logout = false;

        Console.WriteLine($"Benvenuto, {username}!");
        while (!logout)
        {
            Console.WriteLine("Cosa vuoi fare?");
            Console.WriteLine("[1] Visualizza voli disponibili\n[2] Aggiungi volo\n[3] Modifica volo\n[4] Elimina volo\n[0] Logout");
            string scelta = Console.ReadLine() ?? "Campo Obbligatorio";

            switch (scelta)
            {
                case "1":
                    VisualizzaVoli(conn);
                    break;
                case "2":
                    AggiungiVolo(conn); // DA AGGIUNGERE
                    break;
                case "3":
                    ModificaVolo(conn); // DA AGGIUNGERE
                    break;
                case "4":
                    EliminaVolo(conn); // DA AGGIUNGERE
                    break;
                case "0":
                    Console.WriteLine("Logout effettuato.");
                    logout = true;
                    break;
                default:
                    Console.WriteLine("Opzione non valida.");
                    break;
            }
        }
    }

    private static void VisualizzaVoli(MySqlConnection conn)
    {
        string query = @"SELECT volo.volo_id AS VoloID, c1.nome_citta AS Partenza, c2.nome_citta AS Destinazione, volo.numero_posti AS PostiDisponibili, volo.costo AS Prezzo
        from volo
        join citta c1 ON c1.citta_id = volo.partenza_id
        join citta c2 ON c2.citta_id = volo.destinazione_id";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        try
        {
            MySqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Voli disponibili:");
            while (reader.Read())
            {
                Console.WriteLine(@$"ID: {reader["VoloID"]}, Partenza: {reader["Partenza"]}, Destinazione: {reader["Destinazione"]}, Posti Disponibili: {reader["PostiDisponibili"]}, Prezzo: {reader["Prezzo"]}");
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore durante la visualizzazione dei voli: " + ex.Message);
        }
    }

    private static void PrenotaViaggio(MySqlConnection conn, string username)
    {
        VisualizzaVoli(conn);

        Console.WriteLine("Inserisci l'ID del volo che vuoi prenotare: ");
        string voloId = Console.ReadLine() ?? "Campo Obbligatorio";

        // DA FINIRE
    }

    private static void VisualizzaPrenotazioni(MySqlConnection conn, string username)
    {
        string query = @"SELECT p.prenotazione_id AS PrenotazioneID, c1.nome_citta AS Partenza, c2.nome_citta AS Destinazione, p.data_prenotazione AS DataPrenotazione
        FROM prenotazione p
        JOIN volo v ON p.volo_id = v.volo_id
        JOIN citta c1 ON v.partenza_id = c1.citta_id
        JOIN citta c2 ON v.destinazione_id = c2.citta_id
        JOIN utente u ON u.utente_id = p.utente_id
        WHERE u.username = @username";
        
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@username", username);
        
        try
        {
            MySqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Le tue prenotazioni:");
            while (reader.Read())
            {
                Console.WriteLine(@$"ID Prenotazione: {reader["PrenotazioneID"]}, Partenza: {reader["Partenza"]}, Destinazione: {reader["Destinazione"]}, Data Prenotazione: {reader["DataPrenotazione"]}");
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore durante la visualizzazione delle prenotazioni: " + ex.Message);
        }
    }
}
