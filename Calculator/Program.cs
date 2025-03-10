/*
I principi SOLID ( https://www.html.it/guide/solid-guida-ai-principi-basilari-delloop/ )
e le pratiche di Clean Code ()
sono fondamentali per sviluppare software mantenibile, estendibile e testabile.

Principi SOLID:
Single Responsibility Principle (Principio di Responsabilità Singola): Ogni classe deve avere una sola ragione per cambiare.
Open/Closed Principle (Principio Aperto/Chiuso): Le entità software (classi, moduli, funzioni) devono essere aperte all'estensione, ma chiuse alla modifica.
Liskov Substitution Principle (Principio di Sostituzione di Liskov): Le sottoclassi devono poter essere sostituite alle loro classi base senza alterare la correttezza del programma.
Interface Segregation Principle (Principio di Segregazione dell'Interfaccia): Nessun cliente deve essere forzato a dipendere da metodi che non usa.
Dependency Inversion Principle (Principio di Inversione della Dipendenza): Le astrazioni non devono dipendere dai dettagli. I dettagli devono dipendere dalle astrazioni.
Clean Code:

Clean Code, come descritto nel libro di Robert C. Martin, enfatizza la leggibilità, la semplicità e l'organizzazione del codice.

VIDEO 6min: Clean Code, Robert Martin, immancabile! : https://www.youtube.com/watch?v=oZCLMxVBa_c

Alcune pratiche chiave includono:

Nomi significativi per variabili, funzioni e classi.
Funzioni piccole e che fanno una sola cosa.
Evitare commenti inutili e lasciare che il codice si spieghi da solo.
Gestione degli errori robusta e chiara.
Test unitari per garantire la correttezza del codice.
L'applicazione combinata di questi principi porta a un codice più facile da capire, modificare e testare, migliorando la qualità del software e facilitando la collaborazione tra sviluppatori.
*/

using Calculator.UserScreen;

namespace CalculatorSOLID.Calculator
{
    public static class Program
    {
        // Flag per controllare l'uscita del loop
        private static bool exitRequested = false;

        public static void Main(string[] args)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(CtrlCHandler);

            var calcRunner = new CalculatorRunner();

            // Ciclo principale; termina il programma se exitRequested è vero
            while (!exitRequested)
            {

                // Empty Calculator, no operations available
                bool exitStatus = calcRunner.RunIteration(Console.In, Console.Out);
                if (!exitStatus)
                {
                    exitRequested = true;
                }
            }
        }

        // Manipolatore per Ctrl+C
        private static void CtrlCHandler(object? sender, ConsoleCancelEventArgs args)
        {
            // Annulla l'immediata chiusura del programma
            args.Cancel = true;
            exitRequested = true;
            Console.WriteLine("\n\nCtrl+C >>> Richiesta interruzione: terminare l'esecuzione...");
            Environment.Exit(0);
        }
    }
}
