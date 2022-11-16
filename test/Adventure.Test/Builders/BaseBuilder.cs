using Adventure.Test.Builders.AdventureAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Test.Builders
{
    public abstract class BaseBuilder<T, TBuilder>
    {
        public abstract TBuilder WithIsDeleted(bool isDeleted);
        public abstract TBuilder WithCreatedAt(DateTimeOffset createdAt);
        public abstract TBuilder WithUpdatedAt(DateTimeOffset updatedAt);
        public abstract TBuilder WithCreatedBy(string createdBy);
        public abstract TBuilder WithUpdatedBy(string updatedBy);
        public abstract TBuilder WithSystemAsUser();

        protected abstract T Build();

        public static implicit operator T(BaseBuilder<T, TBuilder> builder)
        {
            return builder.Build();
        }

        protected TBuilder CommonReturn<TVal>(TBuilder obj, out TVal property, TVal value)
        {
            property = value;
            return obj;
        }

        protected TBuilder CommonAdd<TVal>(TBuilder obj, ref List<TVal> property, TVal value)
        {
            property.Add(value);
            return obj;
        }
    }
}
