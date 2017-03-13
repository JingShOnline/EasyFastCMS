
/**
 * 
 * @param {any} val
 * @param {any} row
 */
function FormatColumnName(val, row) {
    if (row.ColumnTypeEnum === 1) {
        return '<a href="/Admin/Column/Update/' + row.Id + '">' + val + '</a>';
    }
    if (row.ColumnTypeEnum === 2) {
        return '<a href="/Admin/Column/SingleUpdate/' + row.Id + '">' + val + '</a>';
    }
}