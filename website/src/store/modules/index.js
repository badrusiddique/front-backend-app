const modules = {};
const requireModule = require.context('.', false,  /\.*\.js$/);

requireModule
  .keys()
  .forEach(filename => {
    // create the module name from fileName
    // remove the .js extension and convert kebab-case to pascal-case
    const name = filename
      .replace(/(\.\/|\.js)/g, '')
      .replace(/-./g, x=>x.toUpperCase()[1]);

    modules[name] = requireModule(filename).default || requireModule(filename);
  });

export default modules;
