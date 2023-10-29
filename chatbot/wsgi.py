from flask import Flask, request, jsonify, json
from main import Neural

app = Flask(__name__)

@app.route("/api/question", methods=["POST"])
def hello_world():
    if request.method == 'POST':
        json_dict = request.get_json()
        message = json_dict['message']
        if message != "":
            neural = Neural()
            result = neural.predict(message, True)
            return jsonify(result)
        else:
            message = "Некорректный запрос"
            response = app.response_class(
            response=json.dumps(message),
            status=400,
            mimetype='application/json')
            return response

if __name__ == "__main__":
    # Please do not set debug=True in production
    app.run(host="0.0.0.0", port=5000, debug=True)