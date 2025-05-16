namespace ProcessingPlatform.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            List<int> datas = new List<int>();
            for (int i = 0; i < 100000; i++)
            {
                datas.Add(i);
            }
            Assert.True(true, "True is not true!");
        }
    }
}