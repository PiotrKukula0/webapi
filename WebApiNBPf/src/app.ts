class Main
{

    public static InitKendo()
    {
            $("#grid").kendoGrid({
                dataSource: {
                    transport: {
                        read: function(options)
                        {
                            var settings = {
                            "url": "http://localhost:5230/api/WebApiNBP/get",
                                "method": "GET",
                                "timeout": 0,
                                "headers": {
                                "x-authKey": "uynjsykkloye679km@~556HHTrMolews"
                                },
                            };

                    $.ajax(settings).done(function (response) {
                options.success(response);
});
                        }
                    },
                    schema: {
                        model: {
                            fields: {
                              nazwa_waluty: { type: "string" },
                              kod_waluty: { type: "string" },
                              kurs_sredni: { type: "string" }
                            }
                        }
                    },
                    pageSize: 35,
                    serverPaging: true,
                    serverFiltering: true,
                    serverSorting: true
                    
                },
                height: 550,
                filterable: false,
                sortable: true,
                pageable: true,
                columns: [{
                        field: "nazwa_waluty",
                        title: "Nazwa waluty"
                    },
                    {
                        field: "kod_waluty",
                        title: "Kod waluty"
                    },
                    {
                        field: "kurs_sredni",
                        title: "Kurs średni"
                    }
                ]
            });
        
    }



}