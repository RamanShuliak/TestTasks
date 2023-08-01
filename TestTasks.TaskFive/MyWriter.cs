namespace TestTasks.TaskFive
{
    public class MyWriter : StringWriter
    {
        TextWriter defaultTextWriter = Console.Out;
        public override void WriteLine(string? value) => Console.SetOut(defaultTextWriter);
    }
}