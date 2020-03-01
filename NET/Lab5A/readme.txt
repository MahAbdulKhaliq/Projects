This project - 'Lab5A' - was made during my time at Mohawk College; it was made using Visual Studio 2019.

A debug .exe variant can be found further in the Lab5A/bin/Debug/Lab5A.exe; this does not require Visual Studio 2019 to run (but it does
have a debug label for the level of fluid - be warned!).

This is a Windows Form App written in C#. The app is simple: the user has a bucket that can be filled with fluid (the rate of which being
determined by the level of the 'tick' on the bar). The user can also change colour of the fluid if they so desire (default is blue); the
colour of the fluid will not mix.

Once the beaker is near-full, the rate of flow will cease. If the tap is used again, the beaker will reset and start without any fluid.

The trick here is that when a 'tick' is selected, a timer will start and a rectangle will be drawn using data drawn from the timer. 

Here's a paraphrased description as to how it works:
1) The program checks to see the timer's value: if it is not full, allow time growth; otherwise, reset.
2) When anything above 1 tick is selected, a timer starts. This time added is multiplied by the level of the 'tick'.
3) A rectangle is drawn (height based off of the level of the tick) and the next position for the rectangle being drawn is updated (according to the timer)
4) This process repeats when the timer is active until it is at the marked 'near-full' point.
5) Once the bucket is near-full, the timer will cease and the tick level will be brought to zero.
