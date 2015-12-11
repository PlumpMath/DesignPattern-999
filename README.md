# DesignPattern
Design Patterns Created  over Console as classical as can be
t

#Structural Desighn PAttern

##Facade 
There are some scenarios in our application, we need to work with a series of objects to perform certain task. For example, If we are writing software for a universal remote and I want to turn off all the devices then I have few options. First I can manually select each device and turn them off one by one. This was rather a crude approach so why not automate this inside the remote itself. So I can have a button that will turn off all the devices. Now to turn off all the devices all I need to so is to push this button. The button press command of this remote will now talk to all the device controllers and turn them off.

Now if I need the similar functionality to be executed automatically at 12 o'clock in night. Now this timer based event will also talk to all the devices and stop them all. So the problem here is that in all the scenarios I need to have this functionality I need to talk to these objects.

There is one more approach in designing this solution. Why not have an object whose responsibility is to stop all the devices. Now whenever I need to stop all the devices, I need to call this object only. This is exactly the philosophy behind the facade pattern. GoF defines facade pattern as "Provide a unified interface to a set of interfaces in a subsystem. Façade defines a higher-level interface that makes the subsystem easier to use.

>reference http://www.codeproject.com/Articles/481297/UnderstandingplusandplusImplementingplusFacadeplus
