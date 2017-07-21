using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class ChildRegisterShould: IDisposable
    {
        private readonly ChildRegister _register;
        private readonly DatabaseInterface _db;

        public ChildRegisterShould()
        {
            _db = new DatabaseInterface("BAGOLOOT_TEST_DB");
            _register = new ChildRegister(_db);
            _db.CheckChildTable();
            _db.CheckToyTable();
        }

        [Theory]
        [InlineData("Sarah")]
        [InlineData("Jamal")]
        [InlineData("Kelly")]
        public void AddChildren(string child)
        {
            var result = _register.AddChild(child);
            Assert.True(result != 0);
        }

        [Fact]
        public void ReturnListOfChildren()
        {
            _register.AddChild("Svetlana");
            List<Child> children = _register.GetChildren();
            Assert.IsType<List<Child>>(children);
            Assert.True(children.Count > 0);
        }

        [Fact]
        public void GetAChild()
        {
            int svetlanaId = _register.AddChild("Svetlana");
            Child svetlana = _register.GetChild(svetlanaId);
            Assert.True(svetlana.id == svetlanaId);
        }

        public void Dispose()
        {
            _db.Delete("DELETE FROM toy");
            _db.Delete("DELETE FROM child");
        }
    }
}
