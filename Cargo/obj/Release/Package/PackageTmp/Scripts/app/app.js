var cargoApp = angular.module('cargoApp', ['pascalprecht.translate', 'ui.bootstrap', 'ui.bootstrap.datetimepicker', 'ngFileUpload']);

cargoApp.config(function ($translateProvider) {
    $translateProvider.fallbackLanguage('en');
    $translateProvider.registerAvailableLanguageKeys(['en', 'es'], {
        'en_*' : 'en',
        'es_*' : 'es'
    })

   

    $translateProvider.translations('en', {
        //Slide Menu
        WAREHOUSE: 'Warehouse',
        PARAMETRIZATION: 'Parametrization',
        COMPANIESACCOUNTS:'Accounts',
        //Parametrization
        PARAMETRIZATION_MENU: 'Parametrization options',
        //Unit  Type Create Modal
        CREATEUNITTYPE: 'Create Unit Type',
        UNITTYPENAME: 'Unit Type Name',
        //Branch create
        BRANCHLIST: 'Branch List',
        BRANCHNAME: 'Branch name',
        //Origin
        ORIGINLIST: 'Origin List',
        ORIGINNAME: 'Origin name',
        //Country
        COUNTRYLIST: 'Country list',
        COUNTRYNAME: 'Country name',
        //Classification
        CLASSIFICATIONLIST: 'Clasification List',
        CLASSIFICATIONNAME: 'Clasification Name',
        //Destino
        DESTINATIONLIST: 'Destination List',
        DESTINATIONNAME: 'Destination Name',
        //Condition
        CONDITIONLIST: 'Condition List',
        CONDITIONNAME: 'Condition Name',
        //Notification
        NOTIFICATIONLIST: 'Notification List',
        NOTIFICATIONNAME: 'Notification Name',
        //Warehouse Index
        WAREHOUSELIST: 'Warehouse List',
        //Warehouse Classification
        WAREHOUSECLASSIFICATIONLIST: 'Warehouse Classification List',
        WAREHOUSECLASSIFICATIONNAME: 'Warehouse Classification Name',
        WAREHOUSECLASSIFICATION: 'Warehouse Classification',
        //Company Account
        COMPANIESACCOUNTLIST: 'Accounts List',
        //Delivery create
        DELIVERYCOMPANIESLIST: 'Delivery Companies List',
        DELIVERYCOMPANYNAME: 'Delivery Company Name',
        CREATEDELIVERYCOMPANY:'Create Delivery Company',
        //courierController - Modal
        CORRIER_MODAL_TITLE: 'Add cartons on wharehouse recipt number:',
        UNITS: 'Units',
        UNITTYPE:'Unit Type',
        LENGTH: 'Lenght',
        WIDTH: 'Width',
        HEIGHT: 'Height',
        WEIGHT: 'Weight',
        TRACKING_NUMBER: 'Tracking Number',
        DELIVERY_BY: 'Delivery by',
        ADD_COURIER: 'Add another',
        FINISH: 'Finish',
        ADD: 'Add',
        ADDCOURIER: 'Add courier',
        ADDOTHER:'Add other',
        EDIT: 'Edit',
        PIECES: 'Pieces',
        PIECETYPE: 'Piece Type',
        COURIERINFO:'Courier Information',
        //courierController - Create Warehouse
        CREATE_COURIER_TITLE: 'Create Warehouse',
        CREATIONDATE: 'Date',
        CODENUMBER: 'Number',
        BRANCH: 'Branch',
        SHIPPER: 'Shipper',
        CONSIGNEE: 'Consignee',
        AGENT: 'Agent',
        CONDITION: 'Condition',
        DESCRIPTION:'Description',
        ORIGIN: 'Origin',
        DESTINATION: 'Destination',        
        INVOICECHECK: 'Invoice',
        PACKINGLISTCHECK: 'Packing List',
        LITIUMCHECK: 'Lithium',
        WAREHOUSEINFO: 'Warehouse Information',
        COURIERLIST: 'Courier List',
        //Account Modal
        ACCOUNTLOOKUP: 'Account lookup',
        KEYWORD: 'Keyword',
        SEARCH: 'Search',
        ADVICETEXT: 'Enter a KEYWORD to search for. System will search on company name, city and state.',
        CREATEACCOUNT: 'Create Account',
        SAVE:'Save',
        //Create Account Modal
        ACCOUNTINFO:'Account information',
        COMPANY: 'Company',
        ADRESS: 'Adress',
        CITY: 'City',
        STATE: 'State',
        ZIPCODE: 'Zipcode',
        COUNTRY: 'Country',
        PHONE: 'Phone',
        FAX: 'Fax',
        MOBIL: 'Mobil',
        EMAIL: 'Email',
        CONTACT: 'Contact',
        SAVEACCOUNT: 'Save account',
        ACCOUNTCLASSIFICATION: 'Account Classification',
        ACCOUNTNOTIFICATION: 'Account Notifications',
        WAREHOUSECLASSIFICATION: 'Warehouse Classification',
        //Search Results Modal
        SEARCHRESULTS: 'Search Results',
        COMPANYNAME: 'Company Name',


    });

    $translateProvider.translations('es', {
        //Slide Menu
        WAREHOUSE: 'Almacén',
        PARAMETRIZATION: 'Parametrización',
        COMPANIESACCOUNTS: 'Cuentas',
        //Parametrization
        PARAMETRIZATION_MENU: 'Opciones de parametrización',
        //Modal Unit TYpe
        CREATEUNITTYPE: 'Crear tipo de unidad',
        UNITTYPENAME: 'Nombre del tipo de la unidad',
        //Branch create
        BRANCHLIST: 'Lista de oficinas',
        BRANCHNAME: 'Nombre de la oficina',
        //Origin
        ORIGINLIST: 'Lista de orígenes',
        ORIGINNAME: 'Nombre del orígen',
        //Destino
        DESTINATIONLIST: 'Lista de destinos',
        DESTINATIONNAME: 'Nombre del destino',
        //Condition
        CONDITIONLIST: 'Lista de condiciones',
        CONDITIONNAME: 'Nombre de la condición',
        //Warehouse Classification
        WAREHOUSECLASSIFICATIONLIST: 'Lista de clasificaciones del Almacén',
        WAREHOUSECLASSIFICATIONNAME: 'Nombre de la Clasificación del Almacén',
        WAREHOUSECLASSIFICATION: 'Clasificación del Almacén',
        //Company Account
        COMPANIESACCOUNTLIST: 'Lista de cuentas',
        //Country
        COUNTRYLIST: 'Lista de paises',
        COUNTRYNAME: 'Nombre del país',
        //Notification
        NOTIFICATIONLIST: 'Lista de notificaciones',
        NOTIFICATIONNAME: 'Nombre de la notificación',
        //Classification
        CLASSIFICATIONLIST: 'Lista Clasificaciones',
        CLASSIFICATIONNAME: 'Nombre de la clasificación',
        //Delivery create
        DELIVERYCOMPANIESLIST: 'Lista de Empresas de Envío',
        DELIVERYCOMPANYNAME: 'Nombre de la empresa de envíos',
        CREATEDELIVERYCOMPANY:'Crear Empresa de Envíos',
        //courierController
        CORRIER_MODAL_TITLE: 'Añada las cajas en el almacén con el número de recibo:',
        UNITS: 'Unidades',
        UNITTYPE: 'Tipo de unidad',
        LENGTH: 'Largo',
        WIDTH: 'Ancho',
        HEIGHT: 'Alto',
        WEIGHT: 'Peso',
        TRACKING_NUMBER: 'Número de Rastreo',
        DELIVERY_BY: 'Entregado por',
        ADD_COURIER: 'Añadir otro',
        FINISH: 'Terminar',
        ADD: 'Añadir',
        ADDCOURIER: 'Añadir caja',
        ADDOTHER: 'Añadir otros',
        EDIT: 'Editar',
        PIECES: 'Piezas',
        PIECETYPE:'Tipo de pieza',
        COURIERINFO: 'Información del paquete',
        //courierController - Create Warehouse
        CREATE_COURIER_TITLE: 'Crear Entrada Almacén',
        CREATIONDATE: 'Fecha',
        CODENUMBER: 'Número',
        BRANCH: 'Oficina',
        SHIPPER: 'Remitente',
        CONSIGNEE: 'Destinatario',
        AGENT: 'Agente',
        CONDITION: 'Condición',
        DESCRIPTION: 'Descripción',
        ORIGIN: 'Origen',
        DESTINATION: 'Destino',
        INVOICECHECK: 'Factura',
        PACKINGLISTCHECK: 'Lista de paquetes',
        LITIUMCHECK: 'Litio',
        WAREHOUSEINFO: 'Información del Almacén',
        COURIERLIST: 'Lista de Paquetes',
        SAVE: 'Guardar',
        //Account search modal
        ACCOUNTLOOKUP: 'Búsqueda de cuentas',
        KEYWORD: 'Palabra Clave',
        SEARCH: 'Buscar',
        ADVICETEXT: 'Ingrese una PALABRA CLAVE para buscar. El sistema buscará en los campos de empresa, ciudad y estado.',
        CREATEACCOUNT: 'Crear cuenta',
        SAVEACCOUNT: 'Guardar cuenta',
        //Create Account Modal
        ACCOUNTINFO: 'Información de la cuenta',
        COMPANY: 'Empresa',
        ADRESS: 'Dirección',
        CITY: 'Ciudad',
        STATE: 'Estado',
        ZIPCODE: 'Código Postal',
        COUNTRY: 'Ciudad',
        PHONE: 'Telefono',
        FAX: 'Fax',
        MOBIL: 'Celular',
        EMAIL: 'Email',
        CONTACT: 'Contacto',
        ACCOUNTCLASSIFICATION: 'Clasificación de la cuenta',
        ACCOUNTNOTIFICATION: 'Notificaciones de la cuenta',
        WAREHOUSECLASSIFICATION: 'Clasificación del almacén',
        //Search Results Modal
        SEARCHRESULTS: 'Resultados de la busqueda',
        COMPANYNAME: 'Nombre de la Empresa',

    });

    $translateProvider.useSanitizeValueStrategy('escape');
    $translateProvider.preferredLanguage('en');
});