(function ($) {

        $.fn.ravsAutoComplete = function (options) {
            //debugger;
            var settings = $.extend({
                url: '',
                limit: 100
            }, options);

            this.bind("keyup.ravsAutoComplete", function (event) {
               //debugger;
                var searchText = $(this).val();
                var url = settings.url;

                getDataForAutoComplete(this, url, searchText, settings.limit);

            });

        };


        function getDataForAutoComplete(obj,url,inputText,limit)
        {
            //debugger;
            $.ajax({
                            url: url,
                            type: "GET",
                            dataType: "json",
                            data: { text: inputText, limit: limit },
                            success: function (data) {
                                $("#flyout").remove();
                                if (data.length > 0) {
                                    $(obj).after('<ul id="flyout" class="ui-autocomplete ui-menu ui-widget ui-widget-content ui-corner-all"></ul>');

                                    //Bind click event to list elements in results
                                    $("#flyout").on("click", "li", function () {
                                        $(obj).val($(this).text());
                                        HideElements();
                                    });

                                    //Get
                                    var txtOffSet = $(obj).offset();
                                    var txtHeight = $(obj).height();
                                    var txtWidth = $(obj).width();
                                    //set
                                    $("#flyout").offset({ top: txtOffSet.top + txtHeight, left: txtOffSet.left });
                                    $("#flyout").width(txtWidth);

                                    for (term in data) {
                                        var lielement = $('<li class="ui-menu-item">' + data[term] + '</li>');
                                        $("#flyout").append(lielement);
                                    }
                                }
                                else {
                                    HideElements();
                                }
                            }
                        }); 
        }

        function HideElements()
        {
            $("#flyout").css("display", "none");
            $("#flyout").empty();
        }

}(jQuery));





















