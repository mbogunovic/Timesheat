$(document).ready(function () {
	$(document).on("click", "[data-page], [data-letter], [data-btn-search]",
		function (e) {
			e.preventDefault();

			let kvp = document.location.search.substr(1).split('&');

			const page = $(this).data('page') !== undefined ? $(this).data('page') : $('[data-page-active]').data('pageActive');
			if (page) {
				insertParam(kvp, 'page', page);
			}

			const letter = $('[data-letter]').data('letter');
			if (letter) {
				insertParam(kvp, 'letter', letter);
			}

			const query = $('[data-query]').data('query');
			if (query) {
				inserParam(kvp, 'letter', letter);
			}

			document.location.search = kvp;
		});

	function insertParam(kvp, key, value) {
		key = encodeURI(key);
		value = encodeURI(value);


		var i = kvp.length; var x; while (i--) {
			x = kvp[i].split('=');

			if (x[0] == key) {
				x[1] = value;
				kvp[i] = x.join('=');
				break;
			}
		}

		if (i < 0) { kvp[kvp.length] = [key, value].join('='); }

		return kvp.join('&');
	}
});