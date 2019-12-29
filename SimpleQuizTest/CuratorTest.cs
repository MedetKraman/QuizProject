using SimpleQuiz.Models;
using System;
using Xunit;

namespace SimpleQuizTest
{
    public class CuratorTest
    {
        private const string cid = "e75515ae-cdc3-4252-b477-dce0a15e1fe9";
        private const string Lastname = "Kraman";
        private const string Firstname = "Medet";
        private const string Fathername = "Daniyaruly";
        private readonly CuratorView curator = new CuratorView(new Guid(cid), Lastname, Firstname, Fathername);
        private readonly CuratorView curator2 = new CuratorView(new Guid(cid), Lastname, Firstname, null);

        [Fact]
        public void IdTest()
        {
            Assert.Equal(new Guid(cid), curator.Id);
            Assert.Equal(new Guid(cid), curator2.Id);
        }

        [Fact]
        public void LastnameTest()
        {
            Assert.Equal(Lastname, curator.Lastname);
            Assert.Equal(Lastname, curator2.Lastname);
        }

        [Fact]
        public void FirstnameTest()
        {
            Assert.Equal(Firstname, curator.Firstname);
            Assert.Equal(Firstname, curator2.Firstname);
        }

        [Fact]
        public void FathernameTest()
        {
            Assert.Equal(Fathername, curator.Fathername);
            Assert.Null(curator2.Fathername);
        }
    }
}
