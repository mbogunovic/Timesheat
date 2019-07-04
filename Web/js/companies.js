$(document).ready(function () {
    // bind on page load
    $(".js-company-meals").children().on("click",
        function (e) {
            var form = $(this).closest("form");
            bindClickRemove($(this), $(this).closest("form").find("select[name=MealList]"), "mealid");
            updateHiddenField($(form).find(".js-company-meals").children(), $(form), "mealid", "[name=CompanyMealsIds]");
        });
    $("select[name=MealList]").change(function (e) {
        var target = $(e.target); // select container
        var selectItem = $(this.selectedOptions[0]); // selected value
        if (!$(selectItem).val()) {
            return; // no value (placeholder), skip logic for this one
        }
        var currentForm = $(target).closest('form'); // containing form
        var selectedList = $(currentForm).find('.js-company-meals'); // get the ul with made selections
        // create the li element for made selections list
        var $element = createElement("<li>",
            {
                "data-mealid": $(selectItem).val()
            });
        $element.text($(selectItem).text());
        // add the created element
        appendElement(selectedList, $element);
        var selectedListItems = $(selectedList).children(); //all selected elements
        $(selectedListItems).off("click"); //invalidate old click
        // bind new click
        $(selectedListItems).on("click", function (e) {
            var form = $(this).closest("form");
            bindClickRemove($(this), $(currentForm).find("select[name=MealList]"), "mealid");
            updateHiddenField($(form).find(".js-company-meals").children(), $(form), "mealid", "[name=CompanyMealsIds]");
        });
        updateHiddenField(selectedListItems, currentForm, "mealid", "[name=CompanyMealsIds]");
        $(selectItem).remove(); //remove the element from options
    });
});