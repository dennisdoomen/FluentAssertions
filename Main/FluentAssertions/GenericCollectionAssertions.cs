﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FluentAssertions
{
    public class GenericCollectionAssertions<T> : CollectionAssertions<IEnumerable<T>, GenericCollectionAssertions<T>>
    {
        public GenericCollectionAssertions(IEnumerable<T> actualValue)
        {
            if (actualValue != null)
            {
                Subject = actualValue;
            }
        }

        /// <summary>
        /// Asserts that the collection contains at least one item that matches the predicate.
        /// </summary>
        public AndConstraint<GenericCollectionAssertions<T>> Contain(Expression<Func<T, bool>> predicate)
        {
            return Contain(predicate, string.Empty);
        }

        /// <summary>
        /// Asserts that the collection contains at least one item that matches the predicate.
        /// </summary>
        public AndConstraint<GenericCollectionAssertions<T>> Contain(Expression<Func<T, bool>> predicate, string reason, params object[] reasonParameters)
        {
            if (!Subject.Any(item => predicate.Compile()(item)))
            {
                FailWith("Collection {1} should have an item matching {0}{2}.", predicate.Body, Subject, reason, reasonParameters);
            }

            return new AndConstraint<GenericCollectionAssertions<T>>(this);
        }

        /// <summary>
        /// Asserts that the collection does not contain any items that match the predicate.
        /// </summary>
        public AndConstraint<GenericCollectionAssertions<T>> NotContain(Expression<Func<T, bool>> predicate)
        {
            return NotContain(predicate, string.Empty);
        }

        /// <summary>
        /// Asserts that the collection does not contain any items that match the predicate.
        /// </summary>
        public AndConstraint<GenericCollectionAssertions<T>> NotContain(Expression<Func<T, bool>> predicate, string reason, params object[] reasonParameters)
        {
            if (Subject.Any(item => predicate.Compile()(item)))
            {
                FailWith("Collection {1} should not have any items matching {0}{2}.", predicate.Body, Subject, reason, reasonParameters);
            }

            return new AndConstraint<GenericCollectionAssertions<T>>(this);
        }
    }
}