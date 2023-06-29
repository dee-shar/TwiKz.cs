#!/bin/bash

api="https://tempmail.dev"
user_agent="Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36"

function get_cookies() {
	response=$(curl --request GET \
		--url "$api" \
		--user-agent "$user_agent" \
		-i -s)
	cookie=$(echo "$response" | grep -iE '^set-cookie:' | awk '{print $2}')
	echo $cookie
}

function generate_email() {
	curl --request POST \
		--url "$api/GmailEmail/" \
		--user-agent "$user_agent" \
		--header "cookie: $cookie"
}

function get_inbox() {
	curl --request POST \
		--url "$api/GmailEmail/Inbox" \
		--user-agent "$user_agent" \
		--header "cookie: $cookie"
}
