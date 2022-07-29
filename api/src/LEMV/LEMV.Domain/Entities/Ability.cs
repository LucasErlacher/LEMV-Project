﻿namespace LEMV.Domain.Entities
{
    public class Ability
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public Ability()
        {

        }

        public Ability(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
