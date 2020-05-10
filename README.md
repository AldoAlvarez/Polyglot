# Polyglot

Unity version: 2018.3.12

This is a Unity implementation of a tool for implementing multi-language assets.

Features:
   - Elements are changed accordingly to its type and selected language.
   - Easy to add and remove languages.
   - Easy to scale or inherit from.
   - Contains a serializable dictionary.

How to use:
 
* Set Objects to change its information accordingly to the selected language.

    1. Add <PG_Object> component to any Unity Object.
    2. Create a <PG_ElementsContainer> by going to Assets/Create/Polyglot/Element Container.
    3. Select the type of element (Text, Image, Audio, Video).
    4. Fill fields for each language for the desired type.
    5. Assign the <PG_ElementsContainer> to the <PG_Object>.
    6. Call the method "LoadElement" of <PG_Object> for it to change the data accordingly to the selected language.

* Add and Remove Languages

    1. Create a <PG_ElementsContainer> by going to Assets/Create/Polyglot/Element Container. This will create the "languages" asset if it has not been created.
    2. Go to Resources/Languages and select the "languages.asset" file.
    3. The "Selected Language" parameter will tell which language is currently being applied to all <PG_Objects>. 
    4. "Languages" is a list of strings that contains the definition of all languages that exist at the moment.
    5. To add or remove a language, you can change the size of the list or select an Element and right-click it. Then you can select to duplicate or remove the element without it affecting the <PG_ElementsContainer>.





