var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
var _this = this;
import "jquery";
import "jquery-validation";
import "jquery-validation-unobtrusive";
import "popper.js";
import "bootstrap";
import * as $ from "jquery";
$(function () {
    var updateCijena = function (predmet) { return __awaiter(_this, void 0, void 0, function () {
        var salveta, ukras, cijena;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    salveta = $("[data-moguce-salvete=" + predmet + "]").val();
                    ukras = $("[data-moguce-ukrasavanje=" + predmet + "]").val();
                    return [4 /*yield*/, $.ajax("/Ponuda/DobiCijenu?idPredmet=" + predmet + "&idSalveta=" + salveta + "&idUkras=" + ukras)];
                case 1:
                    cijena = _a.sent();
                    if (cijena != "") {
                        $("[data-submit-kupi=" + predmet + "]").removeAttr("disabled");
                    }
                    else {
                        $("[data-submit-kupi=" + predmet + "]").attr("disabled", "disabled");
                    }
                    $("[data-cijena=" + predmet + "]").html(cijena);
                    return [2 /*return*/];
            }
        });
    }); };
    $("[data-moguce-salvete]").change(function (e, j) { return __awaiter(_this, void 0, void 0, function () {
        var slectedItem, predment, moguciUkrasi, info;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    slectedItem = e.currentTarget.value;
                    predment = e.currentTarget.dataset.moguceSalvete;
                    return [4 /*yield*/, $.ajax("/Ponuda/GetValidStiloviUkrasavanja?idPredmet=" + predment + "&idSalveta=" + slectedItem)];
                case 1:
                    moguciUkrasi = _a.sent();
                    $("[data-mu=" + predment + "]").html(moguciUkrasi);
                    return [4 /*yield*/, $.ajax("/Ponuda/GetSalvetaInfo?idSalveta=" + slectedItem)];
                case 2:
                    info = _a.sent();
                    $("[data-ms-opis=" + predment + "]").html(info);
                    $("[data-mu-opis=" + predment + "]").html("");
                    return [4 /*yield*/, updateCijena(predment)];
                case 3:
                    _a.sent();
                    return [2 /*return*/];
            }
        });
    }); });
    $("[data-sve]").on("change", "[data-moguce-ukrasavanje]", function (e, j) { return __awaiter(_this, void 0, void 0, function () {
        var slectedItem, predment, info;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    console.log(e);
                    slectedItem = e.currentTarget.value;
                    predment = e.currentTarget.dataset.moguceUkrasavanje;
                    return [4 /*yield*/, $.ajax("/Ponuda/GetUkrasavanjeInfo?idUkras=" + slectedItem)];
                case 1:
                    info = _a.sent();
                    $("[data-mu-opis=" + predment + "]").html(info);
                    return [4 /*yield*/, updateCijena(predment)];
                case 2:
                    _a.sent();
                    return [2 /*return*/];
            }
        });
    }); });
    $("[data-filter-narudzbe]").click(function (e, i) { return __awaiter(_this, void 0, void 0, function () {
        var filter, res;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    if (!e)
                        return [2 /*return*/];
                    filter = $(e.currentTarget).data("filterNarudzbe");
                    return [4 /*yield*/, $.ajax("/Narudzbe/FilterNarudzbe?filter=" + filter, { method: "get" })];
                case 1:
                    res = _a.sent();
                    $("#narudzbe").html(res);
                    return [2 /*return*/];
            }
        });
    }); });
    $("body").on("click", "[data-get-comments]", function (e, j) { return __awaiter(_this, void 0, void 0, function () {
        var curTarget, id, comments;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    curTarget = $(e.currentTarget);
                    if (curTarget.hasClass("krc"))
                        return [2 /*return*/];
                    curTarget.addClass("krc");
                    id = curTarget.data("getComments");
                    return [4 /*yield*/, $.ajax("/Price/GetComments?roditelj=" + id, { method: "get" })];
                case 1:
                    comments = _a.sent();
                    $("[data-komentari-za=" + id + "]").html(comments);
                    return [2 /*return*/];
            }
        });
    }); });
    $("body").on("click", "[data-focus]", function (e, j) { return __awaiter(_this, void 0, void 0, function () {
        var curTarget, id, commentRoot;
        return __generator(this, function (_a) {
            curTarget = $(e.currentTarget);
            id = curTarget.data("focus");
            commentRoot = $("[data-comment-root=" + id + "]");
            $("#root").html(commentRoot.html());
            return [2 /*return*/];
        });
    }); });
});
//# sourceMappingURL=site.js.map