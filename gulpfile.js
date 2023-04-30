"use strict";
 
const gulp = require("gulp");
const watch = require("gulp-watch");
const sourcemaps = require("gulp-sourcemaps");
const sass = require('gulp-sass')(require('sass'));
 
var paths = {
    webroot: "./wwwroot/"
};

gulp.task("compile", function () {
    return gulp.src(paths.webroot + '/scss/**/*.scss')
        .pipe(sourcemaps.init()).pipe(sass())
        .pipe(gulp.dest(paths.webroot + '/css/'));
});