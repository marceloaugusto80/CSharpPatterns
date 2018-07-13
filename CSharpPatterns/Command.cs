using System;
using System.Collections.Generic;

namespace CSharpPatterns
{

	public class Target
    {
        public int Value { get; set; }
    }


	public abstract class CommandBase
    {
        public abstract void Execute();
        public abstract void Undo();
    }


    public class SetTargetValueCommand : CommandBase
    {
		public Target Target { get; private set; }
		public int Value { get; private set; }
        private int _targetOldValue;

        public SetTargetValueCommand(Target target, int value)
        {
            Target = target;
            Value = value;
            _targetOldValue = target.Value;

        }

        public override void Execute()
        {
            Target.Value = Value;
        }

        public override void Undo()
        {
            Target.Value = _targetOldValue;
        }
    }


	public class MultiplyTargetValueCommand : CommandBase
    {
		public Target Target { get; private set; }
		public int Factor { get; private set; }

		public MultiplyTargetValueCommand(Target target, int factor)
        {
            Target = target;
            Factor = factor;
        }

		public override void Execute()
        {
            Target.Value *= Factor;
        }

		public override void Undo()
        {
            Target.Value /= Factor;
        }

    }


	public class CommandManager
    {
        private Stack<CommandBase> _undoStack = new Stack<CommandBase>();

        private Stack<CommandBase> _redoStack = new Stack<CommandBase>();


		//


		public int UndoLength
        {
            get
            {
                return _undoStack.Count;
            }
        } 

		public bool HasUndo
        {
            get
            {
                return (_undoStack.Count > 0);
            }
        }

		public int RedoLength
        {
            get
            {
                return _redoStack.Count;
            }
        }

		public bool HasRedo
        {
            get
            {
                return (_redoStack.Count > 0);
            }
        }

        //


        public void Execute(CommandBase command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear();

        }

		public void Undo()
        {
            if (!HasUndo) return;

            CommandBase command = _undoStack.Pop();

            command.Undo();

            _redoStack.Push(command);
        }

		public void Redo()
        {
            if (!HasRedo) return;

            CommandBase command = _redoStack.Pop();

            command.Execute();

            _undoStack.Push(command);
        }


    }

}