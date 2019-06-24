$(document).ready(function () {
	$("form.standard-form.md").on("submit", 
		function(e) {
			e.preventDefault();
			var elements = document.querySelectorAll("[data-val-required]");
			
			elements.forEach(item => $(item).val() === ""
				? $(item).next().text($(item).data("val-required")) && $(item).next().show() && $(item).addClass("invalid")
				: $(item).next().text("") && $(item).next().hide() && $(item).removeClass("invalid"));
			if (!$(".invalid").length) {
				var form = $(this);
				$.post("/ReportAProblem/Submit",
					$(form).serialize(),
					function(data) {
						if (data) {
							$(form).parent().html("<p>" + data + "</p>");
						}
					});
			}
		});
});