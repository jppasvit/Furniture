# Furniture

Augmented reality Unity project that allows locating furniture (tables, shelves, lamps, etc... ) in a specific place.
Project created for ITCL programming challenge 2021. 

## Test

This project has been tested on Android phone Realme 7.

## Instructions

When the application is started we can see a little explanation of which is the function of this app and two buttons. `Start` to start to place furniture and `Exit` to exit the app.

When the principal scene is loaded we have three different furniture to select on top of the screen (lamp, table and shelf), by default table is selected. We locate the furniture in the room clicking on planes that appear. Plane Classification option is enabled so it only allows to put tables on floor, shelves on vertical planes and lamps on planes above the floor. If we want to disable this restriction we have to go to `Options` button and press `Disable Plane Classification`. We could enable this option pressing another time this button.
If we want to manage one of the furniture that are placed, we have to click over one of them and we already have it selected. We can move it through the planes to place it where we want.

For rotate, increase or decrease the size of furniture we have two controls. Left controls are used to modify the furniture direction, with buttons `X`, `Y` and `Z` we select the axis in which we want the furniture change its rotation, with the arrows up and down we apply the rotation. Right controls are used to increase or decrease the furniture size, the arrow up increase the size and the arrow down drecrease it. Both features modifications (rotation and size) are applied to the room furniture selected.

`Options` button show a panel where there are two buttons, one to enable or disable plane classification, another to exit the app. To close options panel press another time on `Options` button.