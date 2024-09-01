using System;

public class Editor
{
    private string content;

    private string[] history;

    int size = 0;

    public void SetContent(string content)
    {
        if(size == 0)
        {
            this.content = content;
        }
        else
        {
            //create history if not exist
            //resize in 1 history
            //history = old_content
            //update content

            if(size == 1)
            {
                history = new string[size];

                history[size - 1] = this.content;

                this.content = content;
            }
            else
            {
                string[] tempHistory = new string[size];
                    
                for(int i = 0; i < history.Length; i++)
                {
                    tempHistory[i] = history[i];
                }

                history = tempHistory;

                history[size - 1] = this.content;
                
                this.content = content;
            }
        }

        size++;
        //Console.WriteLine("Set size = {0}", size);
    }

    public void Print()
    {
        for(int i = 0; i < this.history.Length; i++)
        {
            Console.WriteLine("{0}: {1}", i, this.history[i]);
        }
        
        Console.WriteLine("Corrent content = {0}", this.content);
    }
    public void Undo()
    {
        //Console.WriteLine("Undo 1 size = {0}", size);
        //get the last history 
        this.content = history[this.size - 2];
        
        this.size -= 2;
        //Console.WriteLine("Undo 2 size = {0}", size);
        //resize history by -1
        string[] tempHistory = new string[this.size];

        for(int i = 0; i < size; i++)
        {
            tempHistory[i] = history[i];
        }

        history = tempHistory;

    }

}