using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using MilitaryElite.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Model
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = this.TryParseCorpse(corps);
        }

        public Corps Corps { get; private set; }
        private Corps TryParseCorpse(string corpsStr)
        {
            Corps corps;
            bool parsed = Enum.TryParse<Corps>(corpsStr, out corps);
            if (!parsed)
            {
                throw new InvalidCorpsExeption();
            }
            return corps;
        }
        public override string ToString()
        {
            return base.ToString()+Environment.NewLine+$"Corps: {this.Corps.ToString()}";
        }
    }
}
