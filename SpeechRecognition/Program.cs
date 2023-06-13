using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Speech.Recognition;
using System.Speech.Synthesis;


namespace SpeechRecognition
{
    class Program
    {
        public static void Main()
        {
            // Create a SpeechRecognitionEngine instance
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();

            // Create a SpeechSynthesizer instance
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();

            // Attach an event handler for speech recognized event
            recognizer.SpeechRecognized += (sender, e) =>
            {
                // Get the recognized text
                string recognizedText = e.Result.Text;

                // Write the recognized text
                Console.WriteLine("You said: " + recognizedText);

                // Speak the recognized text
                synthesizer.Speak(recognizedText);
            };

            // Configure the recognizer
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.LoadGrammar(new DictationGrammar());

            // Start the recognition process
            recognizer.RecognizeAsync(RecognizeMode.Multiple);

            // Prompt the user to speak
            Console.WriteLine("Speak now...");

            // Wait for user input to exit
            Console.WriteLine("Press any key to stop listening...");
            Console.ReadKey();

            // Stop the recognition process
            recognizer.RecognizeAsyncStop();
        }
    }
}
