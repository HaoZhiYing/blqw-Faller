using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using blqw;
using System.Linq.Expressions;

namespace Test
{
    [TestClass]
    public class MyTestClass
    {
        void Where(string expected, Expression<Func<User, bool>> expr)
        {
            var parse = Faller.Create(expr);
            var sql = parse.ToWhere(OracleSaw.Instance);
            //parse.Parameters  //解析过程中得到的参数
            Assert.AreEqual(expected, sql);
        }

        void Where2(string expected, Expression<Func<User, bool>> expr)
        {
            var parse = Faller.Create(expr);
            var sql = parse.ToWhere(SqlServerSaw.Instance);
            //parse.Parameters  //解析过程中得到的参数
            Assert.AreEqual(expected, sql);
        }

        void OrderBy(string expected, Expression<Func<User, object>> expr, bool asc)
        {
            var sql = Faller.Create(expr).ToOrderBy(OracleSaw.Instance, asc);
            Assert.AreEqual(expected, sql);
        }
        void Set(string expected, Expression<Func<User>> expr)
        {
            var sql = Faller.Create(expr).ToSets(OracleSaw.Instance);
            Assert.AreEqual(expected, sql);
        }
        void Columns(string expected, Expression<Func<User, object>> expr)
        {
            var sql = Faller.Create(expr).ToSelectColumns(OracleSaw.Instance);
            Assert.AreEqual(expected, sql);
        }
        void Values(string expected, Expression<Func<User, object>> expr)
        {
            var sql = Faller.Create(expr).ToValues(OracleSaw.Instance);
            Assert.AreEqual(expected, sql);
        }
        void ColumnsAndValues(string expected1, string expected2, Expression<Func<User, object>> expr)
        {
            var sql = Faller.Create(expr).ToColumnsAndValues(OracleSaw.Instance);
            Assert.AreEqual(expected1, sql.Key);
            Assert.AreEqual(expected2, sql.Value);
        }

        [TestMethod]
        public void String_Contains()
        {
            Where("NAME IN (:auto_p0, :auto_p1, :auto_p2)", u => "aaa,bbb,ccc".Split(',').Contains(u.Name));
        }


        [TestMethod]
        public void Nullable_ToString()
        {
            Where("TO_CHAR(VALUE) = :auto_p0", u => u.Value.ToString() == "a");
        }
        [TestMethod]
        public void Nullable_Value()
        {
            Where("VALUE = 1", u => u.Value == 1);
            Where("TO_CHAR(VALUE) = :auto_p0", u => u.Value.Value.ToString() == "a");
            Where("VALUE = 1", u => u.Value.Value == 1);
            Where("VALUE IS NULL", u => u.Value.HasValue);
            Where("VALUE IS NOT NULL", u => !u.Value.HasValue);
            Where("VALUE IS NOT NULL", u => u.Value.HasValue == false);
            Where("VALUE IS NOT NULL", u => (!u.Value.HasValue == false) == false);
        }
        [TestMethod]
        public void Double_Not()
        {
            Where("SEX = 0 AND SEX = 0", u => !u.Sex == true && u.Sex != true);
        }

        [TestMethod]
        public void Nullable_Boolean()
        {
            Where("SEX2 = 1", u => u.Sex2 == true);
            Where("SEX2 = 1", u => (bool)u.Sex2);
            Where("SEX2 = 1", u => u.Sex2.Value == true);
        }

        [TestMethod]
        public void Where_Boolean()
        {
            var b = true;
            Where("SEX = 1", u => u.Sex == b);
            Where("SEX = 1", u => u.Sex == true);
            Where("SEX = 0", u => u.Sex == false);
            Where("SEX = 1", u => u.Sex != false);
            Where("SEX = 0", u => !u.Sex != false);
            Where("SEX = 1", u => u.Sex);
            Where("SEX = 0", u => !u.Sex);
        }



        [TestMethod]
        public void Where_String()
        {
            var name = "blqw";
            Where("NAME = :saw_p0", u => u.Name == name);
        }

        [TestMethod]
        public void Where_String2()
        {
            var name = "blqw";
            Where2("Name = @saw_p0", u => u.Name == name);
        }
    }
}
