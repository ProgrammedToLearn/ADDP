using System;
using System.Collections.Generic;
using System.Text;

namespace ADDP.Datastructures {
    /// <summary>Holds a list of objects and releases them according to the FiLo philosophy</summary>
    /// <typeparam name="T">The type of object to hold</typeparam>
    public class Stack<T> {
        /// <summary>The initial stack size when nothing is provided by the user</summary>
        private const int INITIAL_STACK_SIZE = 5;

        /// <summary>The stack of objects</summary>
        private T[] stack;
        /// <summary>How many objects we can hold</summary>
        private int maxStackSize;

        /// <summary>Returns <see langword="true"/> if the stack contains no objects</summary>
        public bool IsEmpty => Size == 0;
        /// <summary>How many objects we are currently holding</summary>
        public int Size { get; private set; }

        /// <summary>Initializes a new stack to use</summary>
        public Stack() : this(INITIAL_STACK_SIZE) { }

        /// <summary>Initializes a new stack to use with a specified number of slots</summary>
        /// <param name="InitialStackSize">How many slots to reserve in the stack</param>
        public Stack(int InitialStackSize) {
            maxStackSize = InitialStackSize;
            stack = new T[InitialStackSize];
            Size = 0;
        }

        /// <summary>Pushes an object into the stack</summary>
        /// <param name="data">The object to push into the stack</param>
        public void Push(T data) {
            if (Size == maxStackSize)
                Resize(maxStackSize * 2);

            stack[Size] = data;

            Size++;
        }

        /// <summary>removes the current top of the stack</summary>
        /// <returns>The object on the top of the stack</returns>
        public T Pop() {
            if (Size == 0)
                return default;

            Size--;

            return stack[Size];
        }

        /// <summary>Looks at the top item on the stack without removing it</summary>
        /// <returns>The object on top of the stack</returns>
        public T Peek() => Size == 0 ? default : stack[Size - 1];

        /// <summary>Resizes the stack to a new size</summary>
        /// <param name="newSize">The new size of the stack</param>
        public void Resize(int newSize) {
            if (newSize < Size)
                return;

            T[] temp = new T[newSize];

            for (int i = 0; i < Size; i++)
                temp[i] = stack[i];

            maxStackSize = newSize;
            stack = temp;
        }
    }
}
