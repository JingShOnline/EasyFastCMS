

/*****解决EasyUITreeGrid卡的问题开始*****/
if ($.fn.datagrid != null && $.fn.datagrid != undefined) {
	var fast_autoSizeColumn = $.fn.datagrid.methods['autoSizeColumn'];
	$.extend($.fn.treegrid.methods, {
		autoSizeColumn: function (jq, field) {
			$.each(jq, function () {
				var opts = $(this).treegrid('options');
				if (!opts.skipAutoSizeColumns) {
					var tg_jq = $(this);
					if (field) fast_autoSizeColumn(tg_jq, field);
					else fast_autoSizeColumn(tg_jq);
				}
			});
		}
	});
}
/*****解决EasyUITreeGrid卡的问题结束*****/

/*****EasyUI自定义扩展开始*****/
Date.prototype.format = function (fmt) { //author: meizz
	var o = {
		"m+": this.getMonth() + 1, //月份
		"d+": this.getDate(), //日
		"H+": this.getHours(), //小时
		"M+": this.getMinutes(), //分
		"s+": this.getSeconds(), //秒
		"q+": Math.floor((this.getMonth() + 3) / 3), //季度
		"S": this.getMilliseconds() //毫秒
	};
	if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
	for (var k in o)
		if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
	return fmt;
}
var EasyUI = {
	TimeFormatter: function (value, rec, index) {
		if (value == undefined) {
			return "";
		}
		value = value.substr(1, value.length - 2);
		var obj = eval('(' + "{Date: new " + value + "}" + ')');
		var dateValue = obj["Date"];
		if (dateValue.getFullYear() < 1900) {
			return "";
		}
		var val = dateValue.format("yyyy-mm-dd HH:MM");
		return val.substr(11, 5);
	},
	DateTimeFormatter: function (value, rec, index) {
		if (value == undefined) {
			return "";
		}
		value = value.substr(1, value.length - 2);
		var obj = eval('(' + "{Date: new " + value + "}" + ')');
		var dateValue = obj["Date"];
		if (dateValue.getFullYear() < 1900) {
			return "";
		}
		return dateValue.format("yyyy-mm-dd HH:MM");
	},
	DateFormatter: function (value, rec, index) {
		if (value == undefined) {
			return "";
		}
		value = value.substr(1, value.length - 2);
		var obj = eval('(' + "{Date: new " + value + "}" + ')');
		var dateValue = obj["Date"];
		if (dateValue.getFullYear() < 1900) {
			return "";
		}
		return dateValue.format("yyyy-mm-dd");
	},
	//案例审批状态
	CaseStatusFormatter: function (value, row) {
		if (value == undefined) {
			return "";
		}
		switch (value) {
			case 0:
				return '<img src="//cdn.jingshonline.com/images/Admin_Case_Status_0.png" title="尚未审批" />';
				break;
			case 1:
				return '<img src="//cdn.jingshonline.com/images/Admin_Case_Status_1.png" title="审批驳回" />';
				break;
			case 2:
				return '<img src="//cdn.jingshonline.com/images/Admin_Case_Status_2.png" title="审批通过" />';
				break;
			case 3:
				return '<img src="//cdn.jingshonline.com/images/Admin_Case_Status_3.png" title="审批通过" />';
				break;
			default:
				return "";
				break;
		}
	},
	//律师审批状态
	LawyerStatusFormatter: function (value, row) {
		if (value == undefined) {
			return "";
		}
		switch (value) {
			case 0:
				return '<img src="//cdn.jingshonline.com/images/icon/16/icon_default.png" title="未提交审核" />';
				break;
			case 1:
				return '<img src="//cdn.jingshonline.com/images/icon/16/icon_bug.png" title="认证审核中" />';
				break;
			case 2:
				return '<img src="//cdn.jingshonline.com/images/icon/16/icon_false.png" title="认证驳回" />';
				break;
			case 3:
				return '<img src="//cdn.jingshonline.com/images/icon/16/icon_true.png" title="认证通过" />';
				break;
			default:
				return "";
				break;
		}
	},
	//性别
	SexFormatter: function (value, row) {
		if (value === true) {
			return '<img src="//cdn.jingshonline.com/images/icon/16/man.gif" title="男" />';
		} else {
			return '<img src="//cdn.jingshonline.com/images/icon/16/female.gif" title="女" />';
		}
	},
	//是否
	BoolFormatter: function (value, row) {
		if (value === true) {
			return '<img src="//cdn.jingshonline.com/images/icon/16/icon_true.png" title="是" />';
		} else {
			return '<img src="//cdn.jingshonline.com/images/icon/16/icon_false.png" title="否" />';
		}
	},
};
/*****EasyUI自定义扩展结束*****/