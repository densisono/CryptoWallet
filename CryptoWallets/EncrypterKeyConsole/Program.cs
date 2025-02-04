using PSS.DHPM.CryptoWallets.DataLayer;
// See https://aka.ms/new-console-template for more information
//string masterKey = "MiClaveMaestra123"; // No guardar en código en producción
Console.WriteLine("Introduzca Llave a Encryptar : ");
string masterKey = Console.ReadLine(); //Global@2025.*
string encryptedKey = CryptoHelper.Encrypt("MiClaveDeCifradoSegura", masterKey);
Console.WriteLine(encryptedKey); // Guarda este resultado en appsettings.json
