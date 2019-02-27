# SymbolicUrlToAdm
I have a problem transferring Siebel Symbolic URLs from one environment to another.

The standard solution for this is the ADM mechanism. Which generates files for import into the necessary environment.
The absolute advantage of this method is mass. At one time you can transport a large number of objects.

However, it is often necessary to transfer one object, then ADM creates 3 files with abstract names and this is not convenient.
To solve the problem, the following approach is proposed:
1. In the application, all the parameters for the Symbolic URL are created and saved to files for ADM import.
2. Files are imported into the desired environment and the created Symbolic URL is checked.
3. If corrections are needed, they are performed in the application and the process is repeated.
