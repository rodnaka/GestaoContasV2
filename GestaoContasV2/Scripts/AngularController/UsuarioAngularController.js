

var app;


(function () {
   
    app = angular.module("UsuarioAngularController", ['ngAnimate', 'ui.bootstrap','ui.mask']);
})();

app.controller("AngularJs_UsuariosController",
    ["$scope", "$timeout", "$rootScope", "$window", "$http",
    function ($scope, $timeout, $rootScope, $window, $http) {
               
        $scope.OptionSexo = [{ NOM_SEXO: 'Selecione' }, { NOM_SEXO: 'Masculino' }, { NOM_SEXO: 'Feminino' }];
        $scope.COD_USUA = 0;
        $scope.COD_ESTA_CIVI = "";
        $scope.COD_TELE = "";
        $scope.NOM_USUA = "";
        $scope.NOM_SEXO = "";
        $scope.NUM_CPF_CNPJ = "";
        $scope.NUM_RG = "";
        $scope.DES_EMAIL = "";
        $scope.NUM_SENH = "";
        $scope.NOM_ORGA_EMIS = "";
        $scope.NOM_ESTA_EMIS = "";
        $scope.NOM_MAE = "";
        $scope.NOM_PAI = "";
        $scope.DES_NATU = "";
        $scope.DAT_INCL_USUA = "";
        $scope.DAT_ALTE_USUA = new Date();
        $scope.DAT_NASC_USUA = "";
        $scope.IND_STAT_USUA = "";
        $scope.COD_ENDE = "";
        $scope.NUM_CEP = "";
        $scope.DES_LOGR = "";
        $scope.NUM_NUME = "";
        $scope.DES_COMP = "";
        $scope.DES_BAIR = "";
        $scope.DES_CIDA = "";
        $scope.DES_ESTA = "";
        $scope.NUM_DDI_CELU = "";
        $scope.NUM_DDD_CELU = "";
        $scope.NUM_TELE_CELU = "";
        $scope.NUM_DDI_FIXO = "";
        $scope.NUM_DDD_FIXO = "";
        $scope.NUM_TELE_FIXO = "";
        $scope.COD_ESTA_CIVI = "";
        $scope.DESC_ESTA_CIVI = "";

        $scope.showStudentAdd = true;
        $scope.addEditStudents = false;
        $scope.StudentsList = true;
        $scope.showItem = true;

        //This variable will be used for Insert/Edit/Delete Students details.
        $scope.stdCodUsuario = 0;
        $scope.stdNome = "";
        $scope.stdEmail = "";

        selectDetalharUsuarioLogin('', '');

        selectDetalharUsuario($scope.stdNome, $scope.stdEmail);        

        function selectDetalharUsuario(UsuarioNome, UsuarioEmail) {
            
            var data1 = $.param({
                nomeUsuario: UsuarioNome,
                emailUsuario: UsuarioEmail
            });

            $http.get('/api/usuarios/selecionarUsuario?' + data1).success(function (data) {
               
                $scope.Usuarios = data;               

                $scope.showStudentAdd = true;
                $scope.addEditStudents = false;
                $scope.StudentsList = true;
                $scope.showItem = true;
            })
           .error(function (data) {
               $scope.error = "An Error has occured while loading posts!";
               alert('Ocorreu um problema no processamento!');
           });
        }

        function selectDetalharUsuarioLogin(UsuarioEmail, UsuarioSenha) {

            var data1 = $.param({
                emailUsuario: UsuarioEmail,
                senhalUsuario: UsuarioSenha
            });

            $http.get('/api/login/selecionarUsuario?' + data1).success(function (data) {
                
                
                $scope.NOM_USUA_LOGIN = data.NOM_USUA;
               
            })
           .error(function (data) {
               $scope.error = "An Error has occured while loading posts!";
               alert('Ocorreu um problema no processamento!');
           });
        }

        function selecionarEstadoCivilTodos() {
            
            $http.get('/api/usuarioestadocivil/selecionarEstadoCivilTodos').success(function (data) {

                $scope.EstadoCivil = data;
            })
           .error(function (data) {
               $scope.error = "An Error has occured while loading posts!";
               alert('Ocorreu um problema no processamento!');
           });
        }


        //Search
        $scope.searchStudentDetails = function () {

            selectDetalharUsuario($scope.stdNome, $scope.stdEmail);
        }

        //Edit Student Details
        $scope.usuarioEditar = function usuarioEditar(COD_USUA, COD_TELE, NOM_USUA, NOM_SEXO, NUM_CPF_CNPJ, NUM_RG, DES_EMAIL
            , NUM_SENH, NOM_ORGA_EMIS, NOM_MAE, NOM_PAI, DES_NATU, DAT_INCL_USUA, DAT_NASC_USUA, IND_STAT_USUA, COD_ENDE, NUM_CEP
            , DES_LOGR, NUM_NUME, DES_COMP, DES_BAIR, DES_CIDA, DES_ESTA, NUM_DDI_CELU, NUM_DDD_CELU, NUM_TELE_CELU, NUM_DDI_FIXO
            , NUM_DDD_FIXO, NUM_TELE_FIXO, COD_ESTA_CIVI, DESC_ESTA_CIVI) {
           
                       
            cleardetails();
            $scope.COD_USUA = COD_USUA;
            $scope.NOM_USUA = NOM_USUA
            $scope.DES_EMAIL = DES_EMAIL;
            $scope.COD_USUA = COD_USUA;           
            $scope.COD_TELE = COD_TELE;
            $scope.NOM_USUA = NOM_USUA;
            $scope.NOM_SEXO = NOM_SEXO.trim();
            $scope.NUM_CPF_CNPJ = NUM_CPF_CNPJ;
            $scope.NUM_RG = NUM_RG;
            $scope.DES_EMAIL = DES_EMAIL;
            $scope.NUM_SENH = NUM_SENH;
            $scope.NOM_ORGA_EMIS = NOM_ORGA_EMIS;
            //$scope.NOM_ESTA_EMIS = NOM_ESTA_EMIS;
            $scope.NOM_MAE = NOM_MAE;
            $scope.NOM_PAI = NOM_PAI;
            $scope.DES_NATU = DES_NATU;
            $scope.DAT_INCL_USUA = DAT_INCL_USUA;
            $scope.DAT_ALTE_USUA = new Date();
            $scope.DAT_NASC_USUA = new Date(DAT_NASC_USUA);
            $scope.IND_STAT_USUA = IND_STAT_USUA;
            $scope.COD_ENDE = COD_ENDE;
            $scope.NUM_CEP = NUM_CEP;
            $scope.DES_LOGR = DES_LOGR;
            $scope.NUM_NUME = NUM_NUME;
            $scope.DES_COMP = DES_COMP;
            $scope.DES_BAIR = DES_BAIR;
            $scope.DES_CIDA = DES_CIDA;
            $scope.DES_ESTA = DES_ESTA;
            $scope.NUM_DDI_CELU = NUM_DDI_CELU;
            $scope.NUM_DDD_CELU = NUM_DDD_CELU;
            $scope.NUM_TELE_CELU = NUM_TELE_CELU;
            $scope.NUM_DDI_FIXO = NUM_DDI_FIXO;
            $scope.NUM_DDD_FIXO = NUM_DDD_FIXO;
            $scope.NUM_TELE_FIXO = NUM_TELE_FIXO;
            $scope.COD_ESTA_CIVI = COD_ESTA_CIVI.toString();
            $scope.DESC_ESTA_CIVI = DESC_ESTA_CIVI;

            $scope.showStudentAdd = true;
            $scope.addEditStudents = true;
            $scope.StudentsList = true;
            $scope.showItem = true;

            selecionarEstadoCivilTodos();
        }

        //Delete Dtudent Detail
        $scope.studentDelete = function studentDelete(StudentID, Name) {

            cleardetails();
            //$scope.Usuario.COD_USUA = StudentID;
            var delConfirm = confirm("Deseja realizar a exclusão do usuário " + Name + " ?");
            if (delConfirm == true) {

                var data = $.param({ tbcc001usua: StudentID });

                $http.delete('/api/usuarios/studentDelete?' + data).success(function (data) {
                      alert("Processamento efetuado com sucesso!");
                      cleardetails();
                      selectDetalharUsuario('', '');
                  })
                .error(function (data) {
                    $scope.error = "An Error has occured while loading posts!";
                    alert('Ocorreu um problema no processamento!');
                });

            }
        }

        // New Student Add Details
        $scope.exibirCadastro = function () {
            cleardetails();
            $scope.showStudentAdd = true;
            $scope.addEditStudents = true;
            $scope.StudentsList = true;
            $scope.showItem = true;

            selecionarEstadoCivilTodos();
        }

        //clear all the control values after insert and edit.
        function cleardetails() {
            $scope.stdCodUsuario = 0;
            $scope.stdNome = "";
            $scope.stdEmail = "";

            $scope.COD_USUA = 0;
            $scope.COD_ESTA_CIVI = "";
            $scope.COD_TELE = "";
            $scope.NOM_USUA = "";
            $scope.NOM_SEXO = "";
            $scope.NUM_CPF_CNPJ = "";
            $scope.NUM_RG = "";
            $scope.DES_EMAIL = "";
            $scope.NUM_SENH = "";
            $scope.NOM_ORGA_EMIS = "";
            $scope.NOM_ESTA_EMIS = "";
            $scope.NOM_MAE = "";
            $scope.NOM_PAI = "";
            $scope.DES_NATU = "";
            $scope.DAT_INCL_USUA = "";
            $scope.DAT_ALTE_USUA = new Date();
            $scope.DAT_NASC_USUA = "";
            $scope.IND_STAT_USUA = "";
            $scope.COD_ENDE = 0;
            $scope.NUM_CEP = "";
            $scope.DES_LOGR = "";
            $scope.NUM_NUME = "";
            $scope.DES_COMP = "";
            $scope.DES_BAIR = "";
            $scope.DES_CIDA = "";
            $scope.DES_ESTA = "";
            $scope.NUM_DDI_CELU = "";
            $scope.NUM_DDD_CELU = "";
            $scope.NUM_TELE_CELU = "";
            $scope.NUM_DDI_FIXO = "";
            $scope.NUM_DDD_FIXO = "";
            $scope.NUM_TELE_FIXO = "";
            $scope.COD_ESTA_CIVI = "";
            $scope.DESC_ESTA_CIVI = "";
        }

        //Form Validation
        $scope.Message = "";
        $scope.IsFormSubmitted = false;

        $scope.IsFormValid = false;


        $scope.$watch("formSalvar.$valid", function (isValid) {
            $scope.IsFormValid = isValid;

        });

        //Save Student
        $scope.salvarUsuario = function () {
           
            $scope.IsFormSubmitted = true;
            if ($scope.IsFormValid) {

                $scope.TBCCC_003_ENDE = {
                    COD_ENDE: $scope.COD_ENDE,
                    NUM_CEP: $scope.NUM_CEP,
                    DES_LOGR: $scope.DES_LOGR,
                    NUM_NUME: $scope.NUM_NUME,
                    DES_COMP: $scope.DES_COMP,
                    DES_BAIR: $scope.DES_BAIR,
                    DES_CIDA: $scope.DES_CIDA,
                    DES_ESTA: $scope.DES_ESTA
                };

                $scope.TBCCC_004_TELE = {
                    COD_TELE: $scope.COD_TELE,
                    NUM_DDI_CELU: $scope.NUM_DDI_CELU,
                    NUM_DDD_CELU: $scope.NUM_DDD_CELU,
                    NUM_TELE_CELU: $scope.NUM_TELE_CELU,
                    NUM_DDI_FIXO: $scope.NUM_DDI_FIXO,
                    NUM_DDD_FIXO: $scope.NUM_DDD_FIXO,
                    NUM_TELE_FIXO: $scope.NUM_TELE_FIXO
                };

                $scope.Usuario = {
                    DES_EMAIL: $scope.DES_EMAIL,
                    NOM_USUA: $scope.NOM_USUA,
                    NOM_SEXO: $scope.NOM_SEXO,
                    NUM_CPF_CNPJ: $scope.NUM_CPF_CNPJ,
                    NUM_RG: $scope.NUM_RG,
                    NUM_SENH: $scope.NUM_SENH,
                    NOM_ORGA_EMIS: $scope.NOM_ORGA_EMIS,
                    NOM_ESTA_EMIS: $scope.NOM_ESTA_EMIS,
                    NOM_MAE: $scope.NOM_MAE,
                    NOM_PAI: $scope.NOM_PAI,
                    DES_NATU: $scope.DES_NATU,
                    DAT_INCL_USUA: new Date(),
                    DAT_ALTE_USUA: new Date(),
                    DAT_NASC_USUA: $scope.DAT_NASC_USUA,
                    IND_STAT_USUA: 'A',
                    COD_ESTA_CIVI: $scope.COD_ESTA_CIVI,
                    TBCCC_003_ENDE: $scope.TBCCC_003_ENDE,
                    TBCCC_004_TELE: $scope.TBCCC_004_TELE
                };

                //if the Student ID=0 means its new Student insert here i will call the Web api insert method
                if ($scope.COD_USUA == 0) {
                    
                    //$http.post('/api/usuarios/inserirUsuario/', { params: { StudentName: $scope.stdNome, StudentEmail: $scope.stdEmail, Phone: $scope.stdTelefone, Address: $scope.stdEndereco } }).success(function (data) {
                    $http.post('/api/usuarios/inserirUsuario/', $scope.Usuario).success(function (data) {

                        $scope.StudentsInserted = data;
                        //alert($scope.StudentsInserted);

                        cleardetails();

                        selectDetalharUsuario('', '');

                        alert('Processamento efetuado com sucesso!');

                    })
             .error(function () {
                 $scope.error = "An Error has occured while loading posts!";
                 alert('Ocorreu um problema no processamento!');
             });
                }
                else {  // to update to the student details

                    $scope.Usuario.COD_USUA = $scope.COD_USUA;

                    $http.put('/api/usuarios/alterarUsuario/', $scope.Usuario).success(function (data) {
                        $scope.StudentsUpdated = data;
                        //alert($scope.StudentsUpdated);

                        cleardetails();

                        selectDetalharUsuario('', '');

                        alert('Processamento efetuado com sucesso!');

                    })
            .error(function () {
                $scope.error = "An Error has occured while loading posts!";
                alert('Ocorreu um problema no processamento!');
            });
                }

            }
            else {
                $scope.Message = "All the fields are required.";
                alert('Campos obrigatórios não foram preenchidos');
            }
        }

        $scope.today = function () {

            $scope.DAT_NASC_USUA = new Date();
        };
        $scope.today();

        $scope.clear = function () {

            $scope.DAT_NASC_USUA = null;
        };

        $scope.inlineOptions = {
            customClass: getDayClass,
            minDate: new Date(),
            showWeeks: true
        };

        $scope.dateOptions = {
            dateDisabled: disabled,
            formatYear: 'yy',
            maxDate: new Date(2020, 5, 22),
            minDate: new Date(),
            startingDay: 1
        };

        // Disable weekend selection
        function disabled(data) {
            var date = data.date,
              mode = data.mode;
            return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
        }

        $scope.toggleMin = function () {
            $scope.inlineOptions.minDate = $scope.inlineOptions.minDate ? null : new Date();
            $scope.dateOptions.minDate = $scope.inlineOptions.minDate;
        };

        $scope.toggleMin();

        $scope.open1 = function () {

            $scope.popup1.Opened = true;

        };
        $scope.setDate = function (year, month, day) {
            $scope.DAT_NASC_USUA = new Date(year, month, day);
        };

        $scope.popup1 = {
            Opened: false
        };

        var tomorrow = new Date();
        tomorrow.setDate(tomorrow.getDate() + 1);
        var afterTomorrow = new Date();
        afterTomorrow.setDate(tomorrow.getDate() + 1);
        $scope.events = [
          {
              date: tomorrow,
              status: 'full'
          },
          {
              date: afterTomorrow,
              status: 'partially'
          }
        ];

        function getDayClass(data) {
            var date = data.date,
              mode = data.mode;
            if (mode === 'day') {
                var dayToCheck = new Date(date).setHours(0, 0, 0, 0);

                for (var i = 0; i < $scope.events.length; i++) {
                    var currentDay = new Date($scope.events[i].date).setHours(0, 0, 0, 0);

                    if (dayToCheck === currentDay) {
                        return $scope.events[i].status;
                    }
                }
            }

            return '';
        }

    }]);
