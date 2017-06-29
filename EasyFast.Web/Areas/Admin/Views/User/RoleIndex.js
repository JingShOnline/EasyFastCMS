﻿(function () {
    $(function () {

        var clear;
        $(function () {
            var i = 0;
            clear = setInterval(function () {
                    if (i <= 10) {
                        clearInterval(clear);
                    }
                    if ($(".panel")[0]) {
                        $(".panel").remove();
                        $(".window-shadow").remove();
                        $(".window-mask").remove();
                        clearInterval(clear);
                    }
                    i++;
                },
                5);

        });
        var _$rolesTable = $('#RolesTable');
        var _roleService = abp.services.app.role;

        var _permissions = {
            create: abp.auth.hasPermission('Pages_Role_Create'),
            edit: abp.auth.hasPermission('Pages_Role_Edit'),
            'delete': abp.auth.hasPermission('Pages_Role_Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Admin/User/CreateOrEditRoleModal',
            scriptUrl: abp.appPath + 'Areas/Admin/Views/User/_CreateOrEditRoleModal.js',
            modalClass: 'CreateOrEditRoleModal'
        });

        _$rolesTable.jtable({
            title: app.localize('Roles'),

            actions: {
                listAction: {
                    method: _roleService.getRoles
                }
            },

            fields: {
                id: {
                    key: true,
                    list: false
                },
                actions: {
                    title: app.localize('Actions'),
                    width: '30%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        //if (_permissions.edit) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Edit') + '"><i class="fa fa-edit"></i></button>&nbsp;')
                            .appendTo($span)
                            .click(function () {
                                _createOrEditModal.open({ id: data.record.id });
                            });
                        //}

                        //if (!data.record.isStatic && _permissions.delete) {
                        $('<button class="btn btn-default btn-xs" title="' + app.localize('Delete') + '"><i class="fa fa-trash-o"></i></button>&nbsp;')
                            .appendTo($span)
                            .click(function () {
                                deleteRole(data.record);
                            });
                        //}

                        return $span;
                    }
                },
                displayName: {
                    title: app.localize('RoleName'),
                    width: '35%',
                    display: function (data) {
                        var $span = $('<span></span>');

                        $span.append(data.record.displayName + " &nbsp; ");

                        if (data.record.isStatic) {
                            $span.append('<span class="label label-info" data-toggle="tooltip" title="' + app.localize('StaticRole_Tooltip') + '" data-placement="top">' + app.localize('Static') + '</span>&nbsp;');
                        }

                        if (data.record.isDefault) {
                            $span.append('<span class="label label-default" data-toggle="tooltip" title="' + app.localize('DefaultRole_Description') + '" data-placement="top">' + app.localize('Default') + '</span>&nbsp;');
                        }

                        $span.find('[data-toggle=tooltip]').tooltip();

                        return $span;
                    }
                },
                creationTime: {
                    title: app.localize('CreationTime'),
                    width: '35%',
                    display: function (data) {
                        return moment(data.record.creationTime).format('L');
                    }
                }
            }

        });

        function deleteRole(role) {
            abp.message.confirm(
                app.localize('RoleDeleteWarningMessage', role.displayName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _roleService.deleteRole({
                            id: role.id
                        }).done(function () {
                            getRoles();
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        };

        $('#CreateNewRoleButton').click(function () {
            _createOrEditModal.open();
        });

        $('#RefreshRolesButton').click(function (e) {
            e.preventDefault();
            getRoles();
        });

        function getRoles() {
            _$rolesTable.jtable('load', { permission: $('#PermissionSelectionCombo').val() });
        }

        abp.event.on('app.createOrEditRoleModalSaved', function () {
            getRoles();
        });

        getRoles();
    });
})();