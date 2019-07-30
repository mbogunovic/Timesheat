$(document).ready(function () {
    // bind on page load
    $(".js-meal-portions").children().on("click",
        function (e) {
            var form = $(this).closest("form");
            bindClickRemove($(this), $(this).closest("form").find("select[name=PortionsList]"), "portioninfo");
            updateHiddenField($(form).find(".js-meal-portions").children(), $(form), "portioninfo", "[name=MealPortionsObjects]");
        });
    $("select[name=PortionsList]").change(function (e) {
        var target = $(e.target); // select container
        var selectItem = $(this.selectedOptions[0]); // selected value
        if (!$(selectItem).val()) {
            return; // no value (placeholder), skip logic for this one
        }
        var currentForm = $(target).closest('form'); // containing form
        var selectedList = $(currentForm).find('.js-meal-portions'); // get the ul with made selections
        // create the li element for made selections list
        var $element = createElement("<li>",
            {
                "data-portioninfo": $(selectItem).val()
            });
        $element.text($(selectItem).text());
        // add the created element
        appendElement(selectedList, $element);
        var selectedListItems = $(selectedList).children(); //all selected elements
        $(selectedListItems).off("click"); //invalidate old click
        // bind new click
        $(selectedListItems).on("click", function (e) {
            var form = $(this).closest("form");
            bindClickRemove($(this), $(currentForm).find("select[name=PortionsList]"), "portioninfo");
            updateHiddenField($(form).find(".js-meal-portions").children(), $(form), "portioninfo", "[name=MealPortionsObjects]");
        });
        updateHiddenField(selectedListItems, currentForm, "portioninfo", "[name=MealPortionsObjects]");
        $(selectItem).remove(); //remove the element from options
    });
});