$(document).ready(function()
{
    $(document).on('click', 'form button[type=submit]', function(e) {
        e.preventDefault();
        const $btnSubmit = $(this);
        const formaction = $btnSubmit.attr("formaction");
        const formmethod = $btnSubmit.attr("formmethod");

        if (formaction !== undefined && formmethod !== undefined) {
            $.ajax({
                type: formmethod,
                url: formaction,
                data: $btnSubmit.closest('form').serialize()
            });
            location.reload();
        } else {
            $btnSubmit.closest('form').submit();
        }
    });
});