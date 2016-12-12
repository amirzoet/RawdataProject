define(['knockout','postman', 'config'], function (ko, postman, config) {
    return function () {
        var menuItems = [
            {title: config.menuItems.search, component: config.components.search},
            {title: config.menuItems.searchHistory, component: config.components.searchHistory},
            {title: config.menuItems.mark, component: config.components.mark }
        ];

        var currentComponent = ko.observable();
        var selectedMenu = ko.observable();

        var selectMenu = function (menu) {
            selectedMenu(menu);
            currentComponent(menu.component);
        }

        var isSelected = function (menu) {
            return menu === selectedMenu();
        }

        postman.subscribe(config.events.changeMenu, function (title) {
            for (var i = 0; i < menuItems.length; i++) {
                if (menuItems[i].title === title) {
                    selectMenu(menuItems[i]);
                    break;
                }
            }
        });

        selectMenu(menuItems[0]);

        return {
            menuItems,
            currentComponent,
            selectMenu,
            isSelected
        }
    }
})