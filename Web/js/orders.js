$(document).ready(function () {
    $('[data-category]').on('change',
        function () {
            const $meals = $(this).closest('.tr').find('[data-meal]');
            $.get("/Order/GetMealList?categoryId=" + this.value,
                function (data) {
                    $meals.find('option:not(:first)').remove();
                    if (data) {
                        $.each(data,
                            function (key, value) {
                                $meals.append('<option value=' + value.Value + '>' + value.Text + '</option>');
                            });
                    } else {
                        $meals.trigger('change');
                    }
                });
        });

    $('[data-meal]').on('change',
        function () {
            const $portions = $(this).closest('.tr').find('[data-portion]');
            $.get("/Order/GetPortionList?mealId=" + this.value,
                function (data) {
                    $portions.find('option:not(:first)').remove();
                    if (data) {
                        $.each(data,
                            function (key, value) {
                                $portions.append('<option value=' + value.Value + '>' + value.Text + '</option>');
                            });
                    }
                });
        });
});