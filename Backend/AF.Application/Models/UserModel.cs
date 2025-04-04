﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AF.Application.Models
{
    public partial class UserModel {

/*        public UserModel(int id, string? name, string? lastName, string? password, string? email, string? phoneNumber, byte[]? profilePicture, string? userType)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            ProfilePicture = profilePicture;
            UserType = userType;
        }*/

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public byte[]? ProfilePicture { get; set; }
        //[NotMapped]
        public string? UserType { get; set; }
        /*Bij UserType zat ik te denken, tijdens het registreren heeft de gebruiker normaal de keuze om aan
         te duiden of hij/zij een huurder of verhuurder is... de waarde uit de (mogelijkse) dropdown box kan dan
        gebruikt worden om bij UserType te zetten. 
        
         
         INFORMATIE OVER NOTMAPPED:
        De [NotMapped]-attribuut voorkomt dat de UserType-eigenschap rechtstreeks wordt opgeslagen in de database. Dit betekent echter niet dat de informatie helemaal verloren gaat. Je kunt nog steeds deze eigenschap gebruiken in je C#-code om te bepalen of een gebruiker een verhuurder of een huurder is.

        Bijvoorbeeld, wanneer een gebruiker zich registreert, kun je de waarde van de UserType-eigenschap instellen op "lessor" of "tenant" afhankelijk van hun keuze. Deze waarde wordt dan lokaal opgeslagen in het object van de gebruiker en kan worden gebruikt voor logica in je applicatie, zoals het weergeven van verschillende functionaliteit op basis van het type gebruiker.
         Dit stelt je in staat om dynamisch gedrag te definiëren op basis van het type gebruiker zonder dat je deze informatie in de database hoeft te dupliceren.
         */
    }
}
