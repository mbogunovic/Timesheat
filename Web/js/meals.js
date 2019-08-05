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
        var $liElement = createElement("<li>",
            {
                "data-portioninfo": ""
            });
        var $spanElement = createElement("<span>",
            {
                "data-portionid": $(selectItem).val()
            });
        var $inputElement = createElement("<input>",
            {
                type: "number",
                min: 0,
                class: "js-portion-price"
            });
        $spanElement.text($(selectItem).text());
        appendElement($liElement, $spanElement);
        appendElement($liElement, $inputElement);
        // add the created element
        appendElement(selectedList, $liElement);
        var selectedListItems = $(selectedList).find("span"); //all selected elements
        $(selectedListItems).off("click"); //invalidate old click
        // bind new click
        $(selectedListItems).on("click", function (e) {
            var form = $(this).closest("form");
            bindClickRemove($(this).parent(), $(this), $(currentForm).find("select[name=PortionsList]"), "portionid");
            updateHiddenField($(form).find(".js-meal-portions").children(), $(form), "portioninfo", "[name=MealPortionsObjects]");
        });
        $(".js-portion-price", currentForm).on("change", function() {
            var portionInfo = $(currentForm).find("li[data-portioninfo]");
            $(portionInfo).data("portioninfo",
                {
                    PortionId: $(portionInfo).find("span[data-portionid]").data("portionid"),
                    Price: $(portionInfo).find(".js-portion-price").val()
        });
        });
        updateHiddenField(selectedListItems, currentForm, "portioninfo", "[name=MealPortionsObjects]");
        $(selectItem).remove(); //remove the element from options
    });
});