const PROXY_CONFIG = [
  {
    context: [
      "/stats",
    ],
    target: "http://localhost:5239/",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
