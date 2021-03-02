using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using TrulliManager.Database.Models;

namespace TrulliManager.Database
{
    public static class TrulliSeedData
    {
        public static void EnsureSeedData(this TrulliContext db)
        {
            BsonObjectId donAntonio = ObjectId.GenerateNewId();
            BsonObjectId cinquenoci = ObjectId.GenerateNewId();
            BsonObjectId carbonaio = ObjectId.GenerateNewId();

            if (db.Properties.CountDocuments(new BsonDocument()) == 0 || db.Trulli.CountDocuments(new BsonDocument()) == 0)
            {

                var properties = new List<Property>
                {
                    new Property
                    {
                        _id = donAntonio.ToString(),
                        Name = "Trulli Don Antonio",
                        City = "Locorotondo",
                        Street = "S.C. 21 C.da Crocifisso n. 9",
                        Spa = true,
                        SwimmingPool = false
                    },
                    new Property
                    {
                        _id = cinquenoci.ToString(),
                        Name = "Trulli Cinquenoci",
                        City = "Locorotondo",
                        Street = "S.C. 126 C.da Cinquenoci n. 6",
                        Spa = false,
                        SwimmingPool = true
                    },
                    new Property
                    {
                        _id = carbonaio.ToString(),
                        Name = "Casa del Carbonaio",
                        City = "Locorotondo",
                        Street = "Via Garibaldi n. 17",
                        Spa = false,
                        SwimmingPool = false
                    }
                };

                var trulli = new List<Trullo>
                {
                    new Trullo
                    {
                        _id = ObjectId.GenerateNewId().ToString(),
                        Property_id = donAntonio.ToString(),
                        Name = "Trullo Panoramico",
                        Description = "Trullo con soppalco con 2 camere da letto e 2 bagni",
                        Capacity = 4,
                        Price = 100
                    },
                    new Trullo
                    {
                        _id = ObjectId.GenerateNewId().ToString(),
                        Property_id = donAntonio.ToString(),
                        Name = "Trullo dell'Interprete",
                        Description = "Trullo in ambiente unico con 1 camera da letto e 1 bagno",
                        Capacity = 3,
                        Price = 80
                    },
                    new Trullo
                    {
                        _id = ObjectId.GenerateNewId().ToString(),
                        Property_id = donAntonio.ToString(),
                        Name = "Trullo dell'Arco",
                        Description = "Trullo ampio con 2 camere da letto e 1 bagno",
                        Capacity = 4,
                        Price = 120
                    },
                    new Trullo
                    {
                        _id = ObjectId.GenerateNewId().ToString(),
                        Property_id = cinquenoci.ToString(),
                        Name = "Trullo Mille Volte",
                        Description = "Trullo a volte in pietra con 3 camere da letto e 2 bagni",
                        Capacity = 7,
                        Price = 180
                    },
                    new Trullo
                    {
                        _id = ObjectId.GenerateNewId().ToString(),
                        Property_id = cinquenoci.ToString(),
                        Name = "Trullo Romantico",
                        Description = "Trullo in ambiente unico con 1 camera da letto e 1 bagno",
                        Capacity = 2,
                        Price = 60
                    },
                    new Trullo
                    {
                        _id = ObjectId.GenerateNewId().ToString(),
                        Property_id = cinquenoci.ToString(),
                        Name = "Trullo Nuovo",
                        Description = "Trullo di nuova costruzione con 2 camere da letto e 1 bagno",
                        Capacity = 4,
                        Price = 120
                    },
                    new Trullo
                    {
                        _id = ObjectId.GenerateNewId().ToString(),
                        Property_id = carbonaio.ToString(),
                        Name = "Trullo del Carbonaio",
                        Description = "Trullo a volte in pietra nel centro storico con 1 camera da letto e 2 bagni",
                        Capacity = 7,
                        Price = 110
                    },
                };

                db.Properties.InsertManyAsync(properties);
                db.Trulli.InsertManyAsync(trulli);
            }
        }
    }
}