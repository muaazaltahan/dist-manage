﻿using System.ComponentModel.DataAnnotations;

namespace dist_manage.DB
{
    public class Cards
    {
        public string Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Sectionid { get; set; } // Foreign Key to Section
        public string Address { get; set; }
        public int Members { get; set; }
        public bool Active { get; set; }
        public string Notes { get; set; }
        public string FormId { get; set; }
        public string FamilyId { get; set; }
        public string FatherStatus { get; set; }
        public string BlueCardId { get; set; }
        public bool HasBlueCard { get; set; }
        public bool Verification { get; set; }
        public static implicit operator CardsDB(Cards db)
        {
            return new CardsDB
            {
                Active = db.Active,
                Notes = db.Notes,
                Address = db.Address,
                Members = db.Members,
                Name = db.Name,
                Phone = db.Phone,
                Sectionid = db.Sectionid,
                Id = db.Id,
                BlueCardId = db.BlueCardId,
                Verification = db.Verification,
                FamilyId = db.FamilyId,
                FatherStatus = db.FatherStatus,
                FormId = db.FormId,
                HasBlueCard = db.HasBlueCard
            };
        }
    }
    public class CardsDB
    {
        [Key] public string Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Phone { get; set; }

        public SectionsDB? Section { get; set; }
        public int? Sectionid { get; set; } // Foreign Key to Section
        public string Address { get; set; }
        public int Members { get; set; }
        public bool Active { get; set; }
        public string Notes { get; set; }
        public string FormId { get; set; }
        public string FamilyId { get; set; }
        public string FatherStatus { get; set; }
        public string BlueCardId { get; set; }
        public bool HasBlueCard { get; set; }
        public bool Verification { get; set; }
    }
}
