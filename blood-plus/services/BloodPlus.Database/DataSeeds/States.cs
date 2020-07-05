using BloodPlus.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodPlus.Database.DataSeeds
{
    public class States : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasData(
                new State {CountryId = 1, Id=1, Name = "Andaman & Nicobar Is"},
                new State {CountryId = 1, Id=2, Name = "Andhra Pradesh"},
                new State {CountryId = 1, Id=3, Name = "Arunachal Pradesh"},
                new State {CountryId = 1, Id=4, Name = "Assam"},
                new State {CountryId = 1, Id=5, Name = "Bihar"},
                new State {CountryId = 1, Id=6, Name = "Chandigarh *"},
                new State {CountryId = 1, Id=7, Name = "Chhattisgarh"},
                new State {CountryId = 1, Id=8, Name = "Dadra & Nagar Haveli"},
                new State {CountryId = 1, Id=9, Name = "Daman & Diu *"},
                new State {CountryId = 1, Id=10, Name = "Delhi *"},
                new State {CountryId = 1, Id=11, Name = "Goa"},
                new State {CountryId = 1, Id=12, Name = "Gujarat"},
                new State {CountryId = 1, Id=13, Name = "Haryana"},
                new State {CountryId = 1, Id=14, Name = "Himachal Pradesh"},
                new State {CountryId = 1, Id=15, Name = "Jammu & Kashmir"},
                new State {CountryId = 1, Id=16, Name = "Jharkhand"},
                new State {CountryId = 1, Id=17, Name = "Karnataka"},
                new State {CountryId = 1, Id=18, Name = "Kerala"},
                new State {CountryId = 1, Id=19, Name = "Lakshadweep *"},
                new State {CountryId = 1, Id=20, Name = "Madhya Pradesh"},
                new State {CountryId = 1, Id=21, Name = "Maharashtra"},
                new State {CountryId = 1, Id=22, Name = "Manipur"},
                new State {CountryId = 1, Id=23, Name = "Meghalaya"},
                new State {CountryId = 1, Id=24, Name = "Mizoram"},
                new State {CountryId = 1, Id=25, Name = "Nagaland"},
                new State {CountryId = 1, Id=26, Name = "Orissa"},
                new State {CountryId = 1, Id=27, Name = "Pondicherry *"},
                new State {CountryId = 1, Id=28, Name = "Punjab"},
                new State {CountryId = 1, Id=29, Name = "Rajasthan"},
                new State {CountryId = 1, Id=30, Name = "Sikkim"},
                new State {CountryId = 1, Id=31, Name = "Tamil Nadu"},
                new State {CountryId = 1, Id=32, Name = "Tripura"},
                new State {CountryId = 1, Id=33, Name = "Uttar Pradesh"},
                new State {CountryId = 1, Id=34, Name = "Uttaranchal"},
                new State {CountryId = 1, Id=35, Name = "West Bengal"}
            );
        }
    }
}
