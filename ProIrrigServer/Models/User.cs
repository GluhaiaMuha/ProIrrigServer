using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Google.Cloud.Firestore;

namespace ProIrrigServer.Models;

[FirestoreData]
public class User
{
    [FirestoreDocumentId]
    public string UId { get; set; }
    
    [FirestoreProperty]
    public string Username { get; set; }
    
    [FirestoreProperty]
    public string Password { get; set; }
}