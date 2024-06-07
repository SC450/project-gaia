# Game Dev Starter Kit Guide for TritonHacks 2024
## Intro
Welcome to TritonHacks 2024! This starter kit will help you learn the fundamentals _(and more!)_ to game development with the Unity engine. This guide covers how to setup, navigate, and script with Unity, and will also go over what assets and built-in mechanics are available for you to create a great game!

This guide has multiple sections based on your experience level. 
- If you have **no experience**, we recommend reading the guide start to finish. 
- If you have experience using a **C-family language** (i.e. Java, C, C#, C++, etc.), we recommend you read the Prerequisites and Navigation sections, and then skip the Scripting section and read from the Assets header onwards.
- If you have experience with a C-family language as well as the **UnityEngine**, you can jump straight to the Assets header and read from there.

## Prerequisites
To get started with this kit, you must have the following completed -- they should already be taken care for you by our team, but in the case you're using a personal device, do these!
- If not done yet, download [Unity Hub](https://unity.com/download), the managing platform for Unity. You can also sign up for a Unity ID if it ever requires it.
- If not done yet, download [Github Desktop](https://desktop.github.com/), a platform for version control for saving your work!
If you haven't yet, sign up or sign in to your github account and fork this repository, then using Github Desktop, sign in and clone your forked respository to somewhere you'll remember.
Next, open Unity Hub, and in Projects, click Open, and select the folder to your repository. It'll next ask you to select **Unity Version 2022.3.4f1**, which if not downloaded, make sure to download!
If you haven't yet, download [Visual Studio](https://visualstudio.microsoft.com/downloads/), an IDE (Integrated Development Environment) for you to code with. Or you can use whichever IDE you prefer, but Visual Studio tends to work best with Unity.
Once your project is finished with first-time setup, open it and you're ready to go.
## Navigation
In the Unity Editor, there are 7 important parts of your screen:
1. The [Toolbar](https://docs.unity3d.com/Manual/Toolbar.html) is the top bar of the editor. It has the play/stop button in the middle, which will compile and run your game, and then it has a pause button, which will freeze the frame of your game when running.
2. The [Game View](https://docs.unity3d.com/Manual/GameView.html) shows what your game looks like from a player’s perspective in the Main Camera, which is an object in your hierarchy.
3. The [Scene View](https://docs.unity3d.com/Manual/UsingTheSceneView.html) shows what your game looks like from a developer’s perspective. Here, you can place, move, rotate, and resize game objects.
4. The [Hierarchy](https://docs.unity3d.com/Manual/Hierarchy.html) is the window that lists all your game objects. Here you can organize your objects and create parent-child relationships between them.
5. The [Project](https://docs.unity3d.com/Manual/ProjectView.html) window contains all the folders for your project’s assets, scenes, and scripts, in which you can drag and drop things into the scene view or the hierarchy to place them into your game.
6. The [Console](https://docs.unity3d.com/Manual/Console.html) is where all text-based output caused by your scripts will show up, whether it be printed messages or errors in your code. You can use this as a basic point of reference for debugging your scripts. Note: If your game isn’t running like it should be when you press play in the toolbar, it may be because you have an error here in the console, and you’ll have to assess it!
7. The [Inspector](https://docs.unity3d.com/Manual/UsingTheInspector.html) is where you can change the properties and the components of either a selected game object or a project asset. This is also where you will drag the scripts you code onto selected game objects to bring them to life.

As one last important note about the inspector: when you’re writing scripts for your project, they _will not run_ if they are not added as a component to an object in the hierarchy/scene view. 

### Navigating in Scene View

To move around in the Scene view, you can **move** by holding _Alt+MiddleMouse (Windows)_ or _Alt+Command+LeftClick (Mac)_  and dragging with your mouse, **orbit** by holding _Alt+LeftClick (Windows/Mac)_ and dragging, and **zoom** by _Scroll Wheel (Windows)_, or _Alt-Control+LeftCLick (Mac)_ and dragging. 

### Tools in Scene View

To use move navigation as you did before but with just left click, you can use the **View Tool**. Use the **Move Tool** to move an object around in 3 directions, **Rotate Tool** to rotate in 3 planes, **Scale Tool** to change its size symmetrically in 3 directions, **Rect Tool** to change its size asymmetrically (as in only one parallel side of a cube moves), and **Transform Tool** to do pretty much all of the above with one weird looking tool.

To begin learning how to write scripts with the rest of the guide, we will add the `Example.cs` script in your assets to the camera. Start by clicking on the `Main Camera` object, scroll all the way down in the inspector tab, click `Add Component`, type and select `Example`. Now the Main Camera has `Example.cs` as an active component.

## Scripting
C# (pronounced "C Sharp") is the programming language that Unity uses, and will be at the core of making things "work" in your game.
### Basics to Programming in C#
#### Structure
To start, you can open Example.cs in the scripts folder of your project window:

<p align="center">
<img src="https://github.com/tritonhacks/TH24-NatureHuntStarter/assets/133953132/9b4e0c25-534c-4917-bf01-ab194a831b2d" alt="scripting-structure" width="400"/>
</p>

Here, there are four main sections, the 🔴**namespace imports**🔴, which allow you to use other built-in Unity code in the script, the 🔵**classes**🔵, which are containers/”templates” of code, which contains two kinds of members, 🟢**data fields**🟢, changeable variables with a type of data, name, and value, and 🧠**methods**🧠, callable functions that runs code whenever it is called. The last three will be explained further in this guide.

#### Variables
Variables are things that hold data in C#. There are many _types_ of variables, including **int**, which are negative/positive whole numbers (-7, 0, 7, etc.), **float**, which are negative/positive decimal numbers (-7.42, 0.00, 7.42, etc.), **string**, which are messages full of characters surrounded by double quotes, such as “Hello World!”, and **bool**, which only have two values, _true_ or _false_. In order to create a variable, you must declare it with its _type_ and _name_.:
```cs
bool counting;
```
...or more commonly, you will define it with an initial _value_ as well:
```cs
bool counting = false;
```
Defining without a value will make it **null**. You then always modify the value of a variable whenever by rewriting them _without_ the type:
```cs
counting = true;
```
Once you've declared a variable, make sure to only change its the value done in the code above. You can not assign a variable a new type!
#### Comments
You can write notes in your scripts that don’t affect the code at all. There are two ways, by line (**```// message```**), or by blocks (**```/* message */```**):
```cs
// This is a line comment.
string message = "This is not a comment.";
/* This is a block comment.
This is still a block comment. */
```
#### Printing
Often, you will want to see the output of your code, particularly to help you _debug_ errors/mistakes you find in your code. You can output values to the console using ```Debug.Log()```:
```cs
Debug.Log("Hello World!");
```
Try writing this inside of the curly braces {} of Example.cs’s method, ```Update()```, and you’ll notice that Hello World! shows up every time a frame passes in the console window once you run your game:

<p align="center">
<img src="https://github.com/tritonhacks/TH24-NatureHuntStarter/assets/133953132/ea67ec53-cf60-49d8-a12e-4ee4fdd06291" width="300px" text-align=>
</p>

To print a variable to see its value, you can type:
```cs
Debug.Log(framesCounted);
```
To output many values in one line, you can use **+** to concatenate them together (**+** on strings will concatenate, but on numbers it will add them as you'll see in the next section).
```cs
Debug.Log(framesCounted + " " + counting);
```

#### Operators
There are three types of operators in C#, **assignment**, **mathematical**, and **logical** operations. Assignment operators are used to assign any value to a variable with a matching type, mathematical operators will always either return an int or float value, and logical operators will always return a bool. 

Here are some tables of the most important operators along with some examples. For the examples, assume that the following is written before trying the example lines of code _independently_:
```cs
// the following will be the example inputs
int x = 10;
float y = 5.5f;
bool a = true;
bool b = false;

// the following will be the example outputs
float z;
bool c;
```

| Operator | Name | Usage | Example | Example Return |
| ---------|------|-------|---------|----------------|
| ```=``` | Assignment | Assigns a value to a variable that matches its type. | ```z = 5f;``` | z is **5f** | 

| Operator | Name | Usage | Example | Example Return |
| ---------|------|-------|---------|----------------|
| ```+``` | Addition | Adds one value to another. | ```z = x + y;``` | z is **15.5f** |
| ```-``` | Subtraction | Subtracts one value from another. | ```z = x - y``` | z is **4.5f** |
| ```*``` | Multiplication | Multiplies one value to another. | ```z = x * y``` | z is **55f** |
| ```/``` | Division | Divides one value from another. | ```z = x / y``` | z is **1.81818...f** |
| ```++``` | Increment | Increases a single value by one. | ```z++``` | z is **z + 1f** |
| ```--``` | Decrement | Decreases a single value by one. | ```z--``` | z is **z - 1f** |

| Operator | Name | Usage | Example | Example Return |
| ---------|------|-------|---------|----------------|
| ```&&``` | AND | True if a AND b is true, else false. | ```c = a && b``` | c is **false** |
| ```¦¦``` | OR | True if a OR b is true, else false. | ```c = a ¦¦ b``` | c is **true** |
| ```!``` | NOT | True if a is false, false if a is true. | ```c = !a``` | c is **false** |
| ```==``` | EQUAL TO | True if x is the same value as y. | ```c = x == y``` | c is **false** |
| ```!=``` | NOT EQUAL TO | True if x is _not_ the same value as y. | ```c = x != y``` | c is **true** |

_Side note, the OR symbol is actually ||, not ¦¦, which was just an alternate symbol used to format the table properly :p_

### Procedural Programming in C#
#### Conditionals
Building off of the logical operators you learned in the previous section, you can call certain blocks of codes if certain conditions using these operators are satisfied to be _true_. We use conditional statements, such as ```if```, ```else if```, and ```else``` statements to do so. These statements look like so:

```cs
if (/* insert first condition here */) {
    /* this code inside of curly braces will run if condition is true */
}
else if (/* insert second condition here */) {
    /* this code will run if the second condition is true AND if the first condition was false */
}
else {
    /* this code will run if both the first AND second conditions were false. */
}
```
- ```if``` statements only run the code inside if its condition is true.
- ```else if``` statements only run if the ```if``` statement before it was false, **and** if its condition itself is true.
- ```else``` statements only run if all conditional statements before it were false. They do _not_ have a (condition).

These conditional statements must always be structured in that sequence, but the ```else if``` and ```else``` statements are optional. You can also write multiple ```else if``` statements to run multiple conditions **sequentially**. You can also put conditional statements _inside_ of conditional statements to test a variety of conditions, which is called **nesting**.

#### Loops
You may find it helpful to have a certain piece of code run multiple times before some condition is reached. To do this, we use loops, such as ```while``` loops, and ```for``` loops. 

```while``` loops look like so:
```cs
while (/* condition */) {
    /* interior code */
}
```
Similarly to conditional statements, ```while``` loops run its code when the condition is true, and will re-run itself until the condition becomes false.

A bit more complex, ```for``` loops look like so:
```cs
for (/* start */ ; /* condition */ ; /* increment */) {
    /* interior code */
}
```
```for``` loops have three lines in its parameters separated by semicolons
- **start** executes _once_ at the start of your loop, and is typically used for initializing an _int_ variable that counts how many times it has looped.
- **condition** executes the condition each time it loops. If it is logically true, then the loop will continue, otherwise it will stop.
- **increment** executes each loop, and is often used to increment the count variable that you created during the start line in order to eventually make the condition true.
Here's an example of the start/condition/increment's traditional use in a for loop:
```cs
for (int i = 0 ; i < 10 ; i++) {
    /* interior code */
}
```
That ```for``` loop will run the interior code 10 times given its parameters.

### Object Oriented Programming in C#
#### Classes & Objects
As mentioned earlier in the Structure section, we can write 🔵**classes**🔵, which are essentially template containers of code, inside of which we write 🔵**members**🔵. Classes can be constructed, meaning that we can “spawn” 🟣**objects**🟣 that are based on a class, and whose members are changeable 🟣**properties**🟣.

As an analogy, let's write a class called Animal outside of the Example class:

<p align="center">
<img src="https://github.com/tritonhacks/TH24-NatureHuntStarter/assets/133953132/21096c3a-a597-43ad-9205-2036e8728737" width="300px" text-align=>
</p>

In the above snippet, we've written our class, 🔵```Animal```🔵, and we have two 🔵**members**🔵, a data field integer called 🟢```age```🟢, and a method called 🧠```Animal()```🧠. Since the method is the same name as the class, it is a 🟣**constructor method**🟣, meaning that when you call it you will construct an object based on the class Animal. Like so:

<p align="center">
<img src="https://github.com/tritonhacks/TH24-NatureHuntStarter/assets/133953132/86a39cb5-d73f-4209-bbc0-271627e199cc" width="300px" text-align=>
</p>

In the above snippet, we have moved to the Example class, where we assign to a new Animal object called 🟣```dog```🟣 the constructor method. We use the 🟣```new```🟣 keyword to _construct_ the object.

In the next line, we want to access the dog's age. To do so, we use the **dot operator (.)**. The dot operator comes after the object, and before the desired property. The dot operator helps us access properties of an object that we can **get** or **set** the value, or **call** a method if we'd like. When we use ```Debug.Log()``` to print the dog's age, we'll see that the age is 0 as we expected, because the ```Animal()``` constructor will set the age to 0 when you create the object.

#### Accessibility

You might have noticed that when writing the Animal class we used the keyword ```public``` before declaring something. ```public``` is an **access modifier**, which changes whether a variable/method/class is accessible elsewhere. In C# there are a few of these, but we really only need to know two for now:

| Keyword | Usage |
| --------|-------|
| **private** _(default it not stated)_ | Can only be accessed/changed in its own class. |
| **public** | Can be accessed/changed in _any_ existing class. |

These keywords are most useful for calling a desired method in another script with **public**, or reusing common names across different classes with **private**.

## UnityEngine

In the UnityEngine, there are plenty of built-in methods/classes/namespaces that make up how your project will work. The following are some important ones:

#### ```void Start()``` _method_
By now, you’ve noticed we’ve coded inside of this [method](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Start.html) in the Example class. The interior code of this method will run only **once** during the very first frame of when you press start. Useful for instantiating/setting things up.

#### ```void Update()``` _method_
We also have worked with this [method](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Update.html) before in Example. The interior code of this method will run **once every frame** that your game is running. Useful for updating variables in your game as time goes on.

#### ```Input``` _class_
This [class](https://docs.unity3d.com/ScriptReference/Input.html) handles user input through keyboard/mouse (as well as controller).
Here are some of the most important methods for keyboard/mouse input:

| Method | Usage |
| --------|-------|
| GetKey | Returns true **while** given key is being held down. |
| GetKeyDown | Returns true on the _first frame_ that a given key is pressed. |
| GetMouseButton | Returns true **while** given mouse button is held down. |
| GetMouseButtonDown | Returns true on the _first frame_ that a given mouse button is pressed. |

For the GetKey functions, you should check out [KeyCode](https://docs.unity3d.com/ScriptReference/KeyCode.html) for all Key inputs.
For the GetMouseButtonfunctions, integers represent the different buttons on a mouse, **0** being Left-click, **1** being Right-click, **2** being Middle-click.

Remember, these are **public methods** of another class, so if you want to call them, you have to use the **dot operator** to call on them! Like so:
```cs
if (Input.GetKeyDown(KeyCode.Space)) {
    /* interior code that runs once the spacekey is pressed, i.e. a player jumping function */
}
```

#### Others _..._
Here are a few others that might be relevant to what you wish to create:

| Name | Usage |
| --------|-------|
| [Collider](https://docs.unity3d.com/ScriptReference/Collider.html) _class_ | Utilizes **Collider** components to detect physical collisions between game objects. |
| [CharacterController](https://docs.unity3d.com/ScriptReference/CharacterController.html) _class_ | Utilizes **CharacterController** components to move game objects around with less reliance on physics. |
| [UnityEngine.UI](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/api/UnityEngine.UI.html) _namespace_ | Contains all the classes necessary to make the **UI** in your game dynamic. More about this one later! |

## Assets

For this project, you are given a wide variety of assets for you to make the game your own. Inside of the Project Window, you’ll find a folder called **/Animals** and a folder called **/Objects**, both of which contain the assets you will be dragging and dropping into your game.

In the Animals folder, you’ll want to drag and drop the Prefab objects into your game. They each come with an animated animal model as well as a given script and component that makes them move and behave in different ways once in the game. Each prefab also has a respective folder filled with its materials and textures in case you'd like to recolor or repurpose them in any way!

In the Objects folder, you’ll find an **/Environmental** folder and a **/Tools** folder, the 
 first is filled with foliage and rocks, and the second is filled with human tools meant for the player to engage in nature preservation. Both do not come with any scripts or components, and it's up to you to come up with and develop mechanics for any that you wish to use.

### Asset Manipulation

If you'd like, you can also duplicate some of the Animal prefabs and make your own from scratch! You can copy and paste one of the prefabs in your Assets folder, then click on it and press Open at the top right of its properties in the Inspector window:

![image](https://github.com/tritonhacks/TH24-NatureHuntStarter/assets/133953132/baa994cc-3958-4519-a78d-4a542f6aad6b)

Once you're inside the Prefab view, you can change a handful of things. On the left side in your hierarchy, you'll see the main parts of the animal, in which we only recommend changing the **"mesh"** and the **"model"** objects. You can alter the size of the model by clicking in _mesh_ and resizing it in the Scene window. You can also duplicate one of the **materials** from the original animal's Assets folder, change how it looks in its properties, then drag and drop it into the components of the _model_ to replace the old material. Materials in Unity combine a texture and the in-game renderer to change the overall color appearance of an object. There's a lot you can do with them, so feel free to toy around with it to make some weird looking animals!

## Mechanics

You currently have three core mechanics of your game built-in for you, the **Pathfinding**, **Terrain**, and **Asset Generation**. Here’s how to tweak them to your liking:

### Pathfinding

The _Pathfinding.cs_ component is found on every Animal prefab, and you can change their Wander Distance, Speed, and their Max Walk & Idle Times in any Animal’s inspector window.
For the changing properties such as speed, check the Animal's **Nav Mesh Agent** component, which controls their navigation. There you can modify steering properties such as translational and rotational speed, acceleration, braking, as well as obstacle properties, which you can modify if your animal changes in size so that it doesn't clip through objects as an example. 

**NOTE:** Everytime you change the terrain in your game, you MUST go to the **Nav Mesh Surface** component under **Terrain Mesh** and click Bake, otherwise your Animals won't be able to navigate the newly-generated ground properly! Baking the terrain takes a cool minute or two, so make sure to click Bake only when you feel your terrain is ready.

### Terrain & Asset Generation

There's a handful you can do with both the terrain and asset generation. 

As a very surface-level description, you can go to the object called **Map Generator** and change the properties in its namesake script component, and then click the Generate button to adjust the map to your liking (remember to bake the terrain's Nav Mesh Surface after)! 
In the same object, you have the **Asset Placement** script, where you can add the Prefab assets we've given you and modify where they can spawn at random, and then click Place Assets. Be a bit more wary with this one, and make sure to adjust the range on your asset placement according to how your terrain looks so that your Animals and Objects spawn in a more natural way.

If you'd like a much more in-depth description of how each property works with both scripts, you can check TERRAINDOC.md in your repository!

## Outro

### Game Design

Now let's get started with coming up with concepts before you build them.

Try to think of what will be your **core gameplay loop**. For example, maybe your player has to search for animals/objects, collect them, and gain points before a timer ends. Or, your player has to help save endangered animals, grow, and repopulate their population with no definite end. In general, find a _"rinse and repeat"_ that will both be entertaining enough for the player, and comprehensive enough for you, the developer. 

Finally, get to **developing your mechanics**! Jot down the main mechanics from your core gameplay loop. For each mechanic, write _psuedocode_ of what inputs and outputs you expect. Also remember that your scripts are components that must be attached to gameObjects! For accessibility and convenience, what objects would work best with holding your scripts? For example, if you write a script called _Eating.cs_ that holds a function that makes animals eat, it might be best to attach _Eating.cs_ to every animal so that you can access an animal's properties. 

Once you feel ready, start scripting, and refer back to your psuedocode if you get lost or have to debug something.

### Support

If this is your first time using Unity, C#, or coding at all, doing a project with this kit might seem daunting, but don't forget about the support you have at this Hackathon! 

If you have trouble coming up with concepts for your game, reach out to your mentor for any ideas they might have, or if you have a team, take some time to talk about inspirations of a game you like, facilitate conversation, and most of all, **write stuff down!**

If you have trouble with coding, try searching for some solutions to any error codes you struggle with in your console, or debug by printing variables that you are concerned might be the source of your problems as you saw earlier in the guide. 
If its been a few frustrating minutes since you started debugging to no avail, ask either your mentor, or put in a ticket to get a tutor to help you out asap! Our job is to help you learn, as well as help you finish a project that will perform well in this Hackathon with zero stress, so don't be afraid to ask for help.

At this point, you are ready to create your own _Nature_ game with this starter kit! Good luck!
